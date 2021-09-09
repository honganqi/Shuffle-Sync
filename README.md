# Shuffle Sync
 Randomly copy files of a specific type to your target path!

Shuffle Sync is a very simple program which allows you to
copy random files of a specific type (usually music or
video files) to a target path or drive.
***Please do be careful with the "Delete all files" option
and the target drive/path. I assume that you know what you are
doing with your drives. I will not be liable for any damages
you incur from this.***

## Features
* Fills the target drive to full capacity
* Specify the source folder
* Specify the target drive (letter)
* Specify the target folder
* Specify the file type(s)
* Empty target folder before copying files

## Usage
* Upon clicking on the "Shuffle Sync" button, the application
will check and warn for the following:
    * if drive is a FIXED drive (usually hard drives)
    * if drive has a total capacity of more than 64GB
    * if the "delete all files" checkbox is marked

If the user approves of all warnings, the application will
proceed to sync files from the source to the destination
(deleting all files in the destination folder if the
`delete all files` checkbox is marked).

This application *probably* requires the .NET Framework 4.5.2
(get it here
https://www.microsoft.com/en-us/download/details.aspx?id=42642.
Compatibility in different versions of Windows is still unknown.

This application is a study project: this is my first C#
application. Help and feedback would be appreciated.

This project was created with Microsoft Visual Studio 2015 Community Edition.