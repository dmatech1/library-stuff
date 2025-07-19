# Floppy Disks

Software
* [samdisk](https://github.com/simonowen/samdisk): Used for parsing `.scp` files.  In particular, I'm using the following subcommands:
  * [`scan`](https://simonowen.com/samdisk/cmd_scan/) for identifying/verifying the encoding, geometry, and quality of the image.
  * [`copy`](https://simonowen.com/samdisk/cmd_copy/) for converting [`.scp`](https://www.cbmstuff.com/downloads/scp/scp_image_specs.txt) files to [other formats](https://simonowen.com/samdisk/formats/).  Useful target formats include [`.edsk`](https://cpctech.cpcwiki.de/docs/extdsk.html), [`.dsk`](https://www.cpcwiki.eu/index.php/Format:DSK_disk_image_file_format), and `.raw`.
* [LIBDSK](https://www.seasip.info/Unix/LibDsk/): A library and tools for working on `.dsk` and `.img` files.  These include mixed sector sizes, but don't include anything that can't be read or written using the standard floppy drive controller.
* [Disk Utilities](https://github.com/keirf/Disk-Utilities.git) by Keir Fraser: Contains tools for imaging with Supercard Pro as well as additional tools for working with images.
* [fdutils](https://fdutils.linux.lu/): Utilities for interacting with the Linux floppy drive controller driver.  Can format disks with `superformat` and query their geometry with `getfdprm`.
* [mtools](https://www.gnu.org/software/mtools/): A collection of utilities to access floppy drives and images with VFAT file systems.  In particular, [`mdir`](https://www.gnu.org/software/mtools/manual/mtools.html#mdir), [`mcopy`](https://www.gnu.org/software/mtools/manual/mtools.html#mcopy), [`minfo`](https://www.gnu.org/software/mtools/manual/mtools.html#minfo), and [`mshowfat`](https://www.gnu.org/software/mtools/manual/mtools.html#mshowfat) are useful.
* [a8rawconv](https://forums.atariage.com/topic/231835-a8rawconv-a-new-raw-disk-conversion-utility/): Designed for Atari disks.  Supports `.scp` files.
* [HxC Floppy Drive Emulator](https://sourceforge.net/projects/hxcfloppyemu/): ...

References
* https://forum.winworldpc.com/discussion/7877/a-comparison-of-current-disk-archival-tools
