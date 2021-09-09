# Changelog
All notable changes to this project will be documented in
this file.

## v.1.3.2 (2016/04/26 01:05 GMT+08:00)
### Fixed
* fixed bug where program does start when the number of drives
is less than the last time it was used, the program was based
on the index position of the drive letter. It is now based on
the actual drive letter.

## v.1.3.1 (2016/04/01 02:25 GMT+08:00)
### Changed
* target drive drop-down list now includes the volume label of
drives and their free space (as recommended by a friend,
thanks Ras!)
 fixed bug indicating "invalid source path" if source path is
 still blank (to avoid an error popping up when clicking on
 the "Browse" button for the source)
### Fixed
* fixed "delete contents" bug related to conditions
* fixed bug where settings were not saving

## v.1.3.0 (2016/03/29 14:14 GMT+08:00)
### Added
* multiple file types now possible: separate with comma ","
* added "sync modes"
    * "until full" - the default and original mode of this
    application
    * "leave free space" - sync until free space is left on
    the drive
    * "number of files" - sync up to number of files only
    * "up to file size" - sync up to total copied file size only
* created a nifty icon (generic icon looks bad, makes the app
look like malware)

## v.1.2.0 (2016/03/24 02:38 GMT+08:00)
### Added
* added progress bar (computes size of files copied vs
available space on target drive)
* added "Cancel" button
### Changed
* minor visual rework
### Fixed
* application no longer "locks up" during syncing

## v.1.1.0 (2016/03/22 15:25 GMT+08:00)
### Added
* added "Browse" button for the source path
* added "Browse" button for the target drive and path
* now checks if drive type is removable and gives warning if not
* now shows basic information of target drive (label, type, capacity, free space)

## v.1.0.0 (2016/03/17 04:02 GMT+08:00)
* initial release
* Fills the target drive to full capacity
* Specify the source folder (no "Browse" button yet)
* Specify the target drive (letter)
* Specify the file type: currently, only one file type can be copied at a time
* Specify the target folder (no "Browse" button yet)
* Empty target folder before copying files
* No progress bar yet