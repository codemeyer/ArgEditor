# Importing and Exporting Data

You can import or export data from and to existing GP.EXE files.

In the main menu, under the File header, you will find functions for
importing and exporting data.


## Importing Data

You can import an entire car set, including car colors, driver performance levels,
horsepower levels, etc, from an existing GP.EXE.

To Import existing data, click on the "Import" button at the top of the screen.
This will open up a "wizard" that lets you select an EXE file to
import data from, and decide which data to import.

![Import](img/import-wizard.png)

Start off by entering the path to the GP.EXE file, or use the Browse button to open a 
file dialog.

When you have selected a GP.EXE file, ArgEditor will write its version information right
below the textbox.

By toggling the various checkboxes you decide which information you want to import.
The various things you can import are grouped by car set data (such as car colors
and driver performance) and game settings (such as the player horsepower value).

If you choose not to import driver numbers, but check the boxes for either driver
performance values or helmet colors, you will receive a warning. This is because the
performance values and helmet colors are dependent on the driver numbers being set
correctly. You can proceed, but results may be unexpected or incorrect.

You can also select a name file that you want to import at the same time. Enter
its path or use the Browse button.

When you have selected everything, click the Import button and ArgEditor will manage
the import for you.



## Exporting Data

When are finished naming and painting, you can export everything to an existing GP.EXE file.

Click the "Export" button at the top of the screen.
Using this menu option will open up a "wizard" that lets you select an EXE file to
export data to, and decide which data to export.

![Export](img/export-wizard.png)

Start off by entering the path to the GP.EXE file, or use the Browse button to open a 
file dialog.

By toggling the various checkboxes you decide which information you want to export.
The various things you can export are grouped by car set data (such as car colors
and driver performance) and game settings (such as the player horsepower value).

If you haven't activated 26 or more drivers, it will not be possible to export driver numbers.
The wizard will inform you of this by disabling the Export button, and displaying an error icon next
to the Driver Numbers checkbox. Hover over the icon to read the tooltip. In the same way
it is not possible to export if two or more drivers have been given the same numbers.

If you do not export driver numbers, you will receive a warning if you try to export driver
performance values or helmet colors, since they are dependent on the driver numbers being set
correctly. You can proceed, but results may be unexpected.

You will also receive a warning if you have selected a normal, non-decompressed GP.EXE file
and are trying to export a points system where drivers who finish between 7th to 26th score any points.
You can perform the export, but only the top six finishers will score points for the championship.

You can also select a name file that you want to export at the same time. Enter
its path or use the Browse button. If the file exists, it will be overwritten.
By default, ArgEditor suggests gpsaves/arged.nam.

If you check the "Load Name File when game starts",
ArgEditor will update your F1GP preferences to automatically load the file.
Note that if you want to auto-load a file, it must be placed in the same folder, or in a child
folder of the specified GP.EXE.

When you have selected everything, click the Export button and ArgEditor will manage
the export for you.

