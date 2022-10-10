# File Systems

* [`losetup`](https://manpages.ubuntu.com/manpages/xenial/man8/losetup.8.html): Can be used to mount an entire drive image as a set of block devices (one for the entirety and one for each partition).

  ```sh
  # Create the devices.
  losetup --direct-io=off --read-only --partscan /dev/loop0 sdc.img
  
  # Destroy the devices.
  losetup -d /dev/loop0
  ```

* [`dmsetup`](https://man7.org/linux/man-pages/man8/dmsetup.8.html): Can be used to create a COW device for emulation or mounting file systems that don't support read-only data.
  * https://gist.github.com/coderjo/c8de3ecc31f1d6450254b5e97ea2c595
  * https://wiki.gentoo.org/wiki/Device-mapper
* [`ntfscluster`](https://manpages.ubuntu.com/manpages/bionic/man8/ntfscluster.8.html): Can be used to identify files that were damaged due to bad sectors in a `ddrescue` dump.
* `btrfs inspect-internal dump-tree`
* `btrfs inspect-internal dump-super`
* `dump.exfat`
* [`fatcat`](https://github.com/Gregwar/fatcat)
* [`iso-info`](https://www.gnu.org/software/libcdio/libcdio.html)
* [`dislocker`](https://github.com/Aorimn/dislocker): Mount encrypted NTFS or exFAT volumes.

  ```sh
  # Show metadata for a BitLocker volume.
  dislocker-metadata -V /dev/sdd1

  # Mount a USB thumbdrive protected by BitLocker.
  mkdir ~/bl-data                                 # dislocker puts a virtual decrypted image here.
  dislocker --user-password /dev/sdd1 ~/bl-data   # Unlock the volume.
  
  mkdir ~/files                                   # This will be the real mount point.
  mount -t exfat ~/bl-data/dislocker-file ~/files # Mount the actual exFAT file system using a loop device.
  
  umount ~/files                                  # Unmount the file system.
  umount ~/bl-data                                # Close dislocker.
  ```
