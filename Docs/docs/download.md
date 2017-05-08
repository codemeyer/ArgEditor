# Download

The latest version is ArgEditorVersionValue. It can be downloaded here: [argeditor-ArgEditorVersionValue.zip](http://www.manicomio.se/argeditor/download/ArgEditor-ArgEditorVersionValue.zip)

## Installation

Unzip and place the argeditor.exe file in your F1GP/WC folder. Then run it from there.

It is better to be safe than sorry! Please make a backup of your F1GP folder before using
this software.

Note: If you are running Windows XP, Windows Vista or Windows 7, your installation of Windows may not
feature the Microsoft .NET Framework 4.0 that is required by ArgEditor. In this case, starting the
program will display an error saying "The application failed to initialize properly." If this happens,
you should try to download and install the Microsoft .NET Framework 4.0 Client Profile, which can
be found here: https://www.microsoft.com/en-us/download/details.aspx?id=24872


## Release notes

### 0.11 (2017-05-??)

* Can create and edit setup files, both single and multiple ones
* Can edit damage settings
* Displays number of active drivers
* Indication (red marker) if two or more drivers share the same numbers
* Indication (orange marker) if a driver has a number assigned, but no name
* Toolbar buttons at the top of each tab replace the main menu
* Added keyboard shortcuts for commonly used commands, see [keyboard shortcuts](keyboard-shortcuts.md)
* UI tightened up to fit into smaller screen resolutions, such as 1024*768
* Fix: Exported player horsepower values in .1ed files are always within F1Ed's allowed range
* Fix: Can export other data if too few drivers are active, but driver numbers are unchecked
* Fix: No longer imports driver numbers even if the checkbox was unchecked
* Fix: Cannot export if auto-loaded file name path is too long
* Fix: Can create a name file without a file extension
* Fix: Correctly show warning when painting a special case helmet
* Fix: Correct behavior when using - to select the next darker color in palette
* Fix: Update qualifying performance list when a driver's performance value changes
* Fix: Don't add undo event if the same color was applied
* Other minor UI tweaks


### 0.10 (2017-04-19)

* Can read and write F1Ed car sets
* Can edit the points system (scoring down to 26th place if using a [decompressed](decompressed-exe.md) exe!)
* [Palette tools](palette-tools.md) for more advanced painting actions
* [Import](importing-and-exporting.md#importing-data) and [Export](importing-and-exporting.md#exporting-data) wizards
* Can edit the general AI grip level
* Can edit wet weather settings
* Can load .CAR (car) and .HEL (helmet) files
* Undo/redo available when copy-pasting car colors
* Copy/paste helmets (including full undo/redo)
* Now also runs on Windows XP
* Minor UI tweaks


### 0.9.2 (2016-08-30)

* Check for update functionality
* Application and window icon
* All helmets can be painted properly (limitations for some still apply)
* Cannot export if you have less than 26 drivers active
* Preview either race or qualifying performance
* Minor UI tweaks


### 0.8 (2015-09-15)

* First release
