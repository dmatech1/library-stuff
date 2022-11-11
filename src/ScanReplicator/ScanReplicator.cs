using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanReplicator {
    class ScanReplicator {
        static string GetEquivalentPath(string oldPath, DirectoryInfo oldRoot, DirectoryInfo newRoot) {
            if (oldPath.StartsWith(oldRoot.FullName)) {
                return newRoot.FullName + oldPath.Substring(oldRoot.FullName.Length);
            }
            throw new Exception("\"" + oldRoot + " does not appear to start with \"" + oldRoot.FullName + "\".");
        }

        static void CreateMigrationScript(DirectoryInfo src, DirectoryInfo dest, TextWriter tw) {
            List<FileSystemInfo> destObjects = new List<FileSystemInfo>(
                dest.EnumerateFileSystemInfos("*", SearchOption.AllDirectories));

            List<FileSystemInfo> srcObjects = new List<FileSystemInfo>(
                src.EnumerateFileSystemInfos("*", SearchOption.AllDirectories));
            
            Dictionary<string, FileInfo> destBasenames = new Dictionary<string, FileInfo>(StringComparer.OrdinalIgnoreCase);
            foreach (var f in destObjects) {
                if (StringComparer.OrdinalIgnoreCase.Equals(".PDF", f.Extension)) {
                    destBasenames[f.Name] = (FileInfo)f;
                }
            }

            // Find directories that need to be created.
            var src_pdf_dirs = srcObjects
                .Where(f => StringComparer.OrdinalIgnoreCase.Equals(".PDF", f.Extension))
                .Where(f => f is FileInfo)
                .Select(f => (FileInfo) f)
                .Select(f => GetEquivalentPath(f.DirectoryName, src, dest))
                .Distinct();

            foreach (var f in src_pdf_dirs) {
                if (!Directory.Exists(f)) {
                    tw.WriteLine("MKDIR \"" + f + "\"");
                }
            }

            // Find files that need to be moved or copied.
            var src_pdfs = srcObjects
                .Where(f => StringComparer.OrdinalIgnoreCase.Equals(".PDF", f.Extension))
                .Where(f => f is FileInfo)
                .Select(f => (FileInfo) f);

            foreach (var f in src_pdfs) {
                FileInfo fi;
                string expectedFlashLocation = GetEquivalentPath(f.FullName, src, dest);

                if (destBasenames.TryGetValue(f.Name, out fi) && (fi.Length == f.Length)) {
                    if (expectedFlashLocation != fi.FullName) {
                        tw.WriteLine("MOVE \"{0}\" \"{1}\"", fi.FullName, expectedFlashLocation);
                    }
                } else {
                    tw.WriteLine("COPY \"{0}\" \"{1}\"", f.FullName, expectedFlashLocation);
                }

            }           
        }

        static void Main(string[] args) {
            Console.WriteLine("ECHO ON");
            CreateMigrationScript(new DirectoryInfo(args[0]), new DirectoryInfo(args[1]), Console.Out);
        }
    }
}
