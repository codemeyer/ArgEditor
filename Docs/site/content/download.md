---
title: "ArgEditor: Download"
---

# Download

<p>
    The latest version is <strong>1.0.1</strong>, released on 2019-04-24.
</p>

<p>
    <a class="btn btn-primary" href="/downloads/argeditor/ArgEditor-1.0.1.zip">Download</a>
</p>

<h2 id="installation">Installation</h2>

<p>
    Unzip and place the argeditor.exe anywhere you like, e.g. in your F1GP/WC folder. Then run it from there.
</p>
<p>
    It is better to be safe than sorry! Please make a backup of your F1GP folder before using
    this software.
</p>
<p>
    Note: If you are running Windows XP, Windows Vista or Windows 7, your installation of Windows may not
    feature the Microsoft .NET Framework 4.0 that is required by ArgEditor. In this case, starting the
    program will display an error saying "The application failed to initialize properly." If this happens,
    you should try to download and install the Microsoft .NET Framework 4.0 Client Profile, which can
    be found here:
    <a href="https://www.microsoft.com/en-us/download/details.aspx?id=24872">https://www.microsoft.com/en-us/download/details.aspx?id=24872</a>
</p>


## Release notes

### 1.0.1

Released 2019-04-24 - [Download](/downloads/argeditor/ArgEditor-1.0.1.zip)

* Fix Redo car painting bug
* Fix invalid path in Export
* Update link to ArgEditor website in About box
* Add links to community sites in About box


### 1.0
Released 2018-02-18 - [Download](/downloads/argeditor/ArgEditor-1.0.0.118.zip)

* You can associate .arged files with ArgEditor.exe and load carsets directly from e.g. Windows Explorer
* Fix for the "jumping" helmet selection screen


### 0.13
Released 2017-06-25

* Can copy all multi-setup race setups to their respective qualifying slots, or vice versa
* Can copy single multi-setup race setup to its qualifying slot, or vice versa
* Can load or save single setups to/from multi-setup slots
* Clearer indication of selected car/helmet
* Fix: Multi-setups sometimes did not save the selected tyre compound, using the default C instead


### 0.12
Released 2017-05-12

* The selected car/helmet is marked with a darker border in the left-side menus
* Reorganized top menu, importing/exporting is now always done via the wizard
* The import/export wizards remember your latest settings as long as ArgEditor is running
* Opening the help documentation by tapping F1 opens documentation for the specific tab that is open
* Fix: ArgEditor does not crash when attempting to load a name file that is not actually a name file
* Fix: Can create a name file without a file extension, fixed for real this time...


<h3 id="011-2017-05-10">
    0.11 (2017-05-10)
</h3>
<ul>
    <li>Can create and edit setup files, both single and multiple ones</li>
    <li>Can edit damage settings</li>
    <li>Displays number of active drivers</li>
    <li>Indication (red marker) if two or more drivers share the same numbers</li>
    <li>Indication (orange marker) if a driver has a number assigned, but no name</li>
    <li>Toolbar buttons at the top of each tab replace the main menu</li>
    <li>Possible to paint all helmets, even for inactive drivers</li>
    <li>Show warnings if painting an inactive car or helmet</li>
    <li>Added keyboard shortcuts for commonly used commands, see <a href="/argeditor/keyboard-shortcuts/">keyboard shortcuts</a></li>
    <li>UI tightened up to fit into smaller screen resolutions, such as 1024*768</li>
    <li>Fix: Exported player horsepower values in .1ed files are always within F1Ed's allowed range</li>
    <li>Fix: Can export other data if too few drivers are active, but driver numbers are unchecked</li>
    <li>Fix: No longer imports driver numbers even if the checkbox was unchecked</li>
    <li>Fix: Cannot export if auto-loaded file name path is too long</li>
    <li>Fix: Can create a name file without a file extension</li>
    <li>Fix: Correctly show warning when painting a special case helmet</li>
    <li>Fix: Correct behavior when using - to select the next darker color in palette</li>
    <li>Fix: Update qualifying performance list when a driver's performance value changes</li>
    <li>Fix: Don't add undo event if the same color was applied</li>
    <li>Other minor UI tweaks</li>
</ul>


<h3 id="010-2017-04-19">
    0.10 (2017-04-19)
</h3>
<ul>
    <li>Can read and write F1Ed car sets</li>
    <li>Can edit the points system (scoring down to 26th place if using a <a href="/argeditor/decompressed-exe/">decompressed</a> exe!)</li>
    <li><a href="/argeditor/palette-tools/">Palette tools</a> for more advanced painting actions</li>
    <li><a href="/argeditor/importing-and-exporting/#importing-data">Import</a> and <a href="/argeditor/importing-and-exporting/#exporting-data">Export</a> wizards</li>
    <li>Can edit the general AI grip level</li>
    <li>Can edit wet weather settings</li>
    <li>Can load .CAR (car) and .HEL (helmet) files</li>
    <li>Undo/redo available when copy-pasting car colors</li>
    <li>Copy/paste helmets (including full undo/redo)</li>
    <li>Now also runs on Windows XP</li>
    <li>Minor UI tweaks</li>
</ul>


<h3 id="092-2016-08-30">
    0.9.2 (2016-08-30)
</h3>
<ul>
    <li>Check for update functionality</li>
    <li>Application and window icon</li>
    <li>All helmets can be painted properly (limitations for some still apply)</li>
    <li>Cannot export if you have less than 26 drivers active</li>
    <li>Preview either race or qualifying performance</li>
    <li>Minor UI tweaks</li>
</ul>


<h3 id="08-2015-09-15">
    0.8 (2015-09-15)
</h3>
<ul>
    <li>First release</li>
</ul>
