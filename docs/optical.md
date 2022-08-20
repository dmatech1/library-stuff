# Optical Media

To-Do
* Describe various sector formats.
  * 3234-byte sectors are the true format of a CD, but you'll never see this.  Only the drive firmware does.
  * 2448-byte sectors ...
  * 2352-byte sectors ...
  * 2048-byte sectors are what you see if you try to "image" a CD-ROM using `/dev/sr0` and `ddrescue`.  This is what gets put into an `.iso` file and is good enough for most stuff.  This contains no subcodes or ECC information.

Software
* [`cdrdao`](http://cdrdao.sourceforge.net/): Disk-At-Once Recording of Audio and Data CD-Rs/CD-RWs
* [`wodim`](https://packages.debian.org/sid/wodim) and `readom`: wodim allows you to create CDs or DVDs on a CD/DVD recorder. It supports writing data, audio, mixed, multi-session, and CD+ disc and DVD data and video disks on DVD capable devices, on just about every type of CD/DVD recorder out there.
* [`dvd+rw-mediainfo`](http://fy.chalmers.se/~appro/linux/DVD+RW/): Retrieves media DVD media type and information.
* [cdemu](https://cdemu.sourceforge.io/): A software suite designed to emulate an optical drive and disc.
  * [libMirage](https://cdemu.sourceforge.io/about/libmirage/): A CD-ROM image access library.
* [Alcohol 120%](https://www.alcohol-soft.com/): Creates backups of CDs and DVDs.  Can also determine the type of copy protection used on some discs.
* [DiscImageCreator](https://github.com/saramibreak/DiscImageCreator): This is [redump.org's tool](http://forum.redump.org/topic/10483/discimagecreator/) for dumping optical discs.