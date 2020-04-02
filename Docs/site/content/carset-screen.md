---
title: "ArgEditor: Car Set Screen"
markup: "mmark"
---

# Car Set Screen

The Car Sets screen has a number of tabs at the top of the screen, with
something of a natural order to them. In the first,
you enter the teams and drivers, on the second tab you set their performance,
on the third you paint the cars and pit crews. On the fourth
tab you paint the drivers' helmets, and on the final tab you edit the points system.

At the top you find buttons for loading and saving car sets, and 
[importing and exporting](/argeditor/importing-and-exporting/) data.

When you open a car set file, you can choose either ArgEditor files (.arged) or old F1ed files (.1ed).

When saving, you can save either an ArgEditor car set file, or a F1Ed file that can be read by F1Ed.

Game settings such as player horsepower, general grip level and weather settings are <em>not</em>
saved in ArgEditor car set files, but <em>are</em> saved in F1Ed files.


## Teams and Drivers tab

This is where you enter team names and their engines, one or two drivers for
each team. You must also set a number for the driver, where the numbers available
range from 1 to 40.

<img alt="Teams and drivers tab screenshot" src="/argeditor/images/teams-and-drivers.png" class="img-fluid" />

There must be at least 26 active drivers. Two drivers cannot have the same numbers.
Active drivers are those that have a number set. If you have enabled a driver by
giving them a number, you can disable them again by selecting the empty value at the
top of the driver number list.

If you set the same number for two or more drivers, a red marker will appear next
to the driver number dropdowns for the affected drivers.

A driver's name can be 23 characters long, but may appear cut off in-game if it
is longer than 18 characters, depending on the width of the characters.
Team and engine names can be 12 characters long.

If you give a driver a number, but do not set a name, an orange marker will appear
next to the driver number dropdown for the affected driver.

Note that the first team in the list has different panel shapes compared to the other
teams. This is because the first team in 1991 was McLaren,
which had the well-known Marlboro paint scheme
with a red diagonal stripe across the nose cone.


## Performance tab

<img alt="Performance tab screenshot" src="/argeditor/images/performance.png" class="img-fluid" />

Each team has a horsepower value (HP) which determine how fast the cars will be in a straight line,
where higher is better.

Drivers have two performance levels, one for qualifying and one for the race. A lower
value means better performance level, so think of the value you are setting as
a "penalty" that slows the driver down.

Apart from entering a numerical value with the keyboard, you can also use the + and -
keys to increase/decrease the values. If you hold down the Shift key, values will
increase/decrease by 10.

On the right you will see a rough estimate of how drivers will perform relative
to each other. When you are editing a driver, they will be displayed in bold text in the list.
When you edit a team, both the team's drivers will appear in bold.

You can toggle between the Qual(ifying) and Race performance values,
and choose if you want to see the estimated performance for slow, medium or
fast tracks.

At high speed tracks like Hockenheim and Monza, the horsepower value
will have a much greater effect on the lap times. At the opposite end of the
spectrum, lap times at Monte Carlo and Phoenix will be much more influenced by the performance level
of the drivers. Medium speeds tracks are somewhere in the middle, like Mexico City and Estoril.

The relative performance is calculated using a formula developed by Hrvoje Štimac,
Ivanhoe Vasiljevich and René Smit for the [LapCalc](https://sites.google.com/view/f1gpwc/file-archive/f1gp-wc-related-utilities/lapcalc) tool.



### Suitable values

In F1GP, teams have horsepower values ranging from 716 at the top to 610 at the
bottom, and drivers have their performance levels in order, from 1 at the top to 34 at
the bottom. This is not necessary however, any number of drivers can have the
same performance level values.

Performance levels can be set as high as 255, but then the driver will just
trundle along the track, sliding like a drift racer. I would not recommend
going above 50.


### Performance levels and qualifying sessions

A thing to note is that when you completely skip the qualifying session in
F1GP, the grid that the game sets up for you is <em>only</em> based on the horsepower
value of the car, and not at all by the driver performance level. Therefore, skipping the
qualifying session will remove any performance differences you have set between
team-mates.



## Cars tab

This is where you paint cars and pit crews.

<img alt="Cars tab screenshot" src="/argeditor/images/cars.png" class="img-fluid" />

Click on a car in the left part of the screen to paint it. Painting is done by
using the <a href="/argeditor/palette-tools">palette tools</a>, which allow you to paint panels,
select the color of an existing panel, and darken or brighten a panel.

The same applies for painting the pit crew. To help you paint the socks, which
have a very small area in the preview box, you can click on the little square
to the left.

As noted above in the Teams and Drivers section, the first car - McLaren in
the default game - has a slightly different panel layout on the nose.

You can undo a painting action with Ctrl+Z and redo actions with Ctrl+Y.

By right-clicking on a car in the menu on the left,
a context menu appears. It has three actions:

* Copy, which copies the selected car to the clipboard
* Paste, which pastes a car from the clipboard to the selected position
* Load .CAR File, which allows you to load a .CAR file from disk to update the selected car

These options are also available for the currently selected car in the toolbar
above the tab.


You can paint all cars, including those that belong to teams that have no active drivers.
However, a team with no active drivers will not appear in the game. One area of usage
could be if you want to include an alternative paint job in your car set, for example.


## Helmets tab

Here is where you paint driver helmets.

<img alt="Helmets tab screenshot" src="/argeditor/images/helmets.png" class="img-fluid" />

The selection and painting works in the same way as in the Cars tab, see the
<a href="/argeditor/palette-tools/">palette tools</a> page for more information.

By right-clicking on a helmet in the list of helmets on the left,
a context menu appears. It has three actions:

* Copy, which copies the selected helmet to the clipboard
* Paste, which pastes a helmet from the clipboard to the selected position
* Load .HEL File, which allows you to load a .HEL file from disk to update the selected helmet

These options are also available for the currently selected car in the toolbar
above the tab.

You can paint all helmets, including those that belong to drivers that are not active.
However, an inactive driver will not appear in the game. One area of usage could be
if you want to include an alternative paint job in your car set, for example.


### Helmets behaving differently

Presumably for optimization reasons, some helmets in the game have fewer colors
available to them. Helmets for drivers with #13, #15, #36, #37, #38, #39 and #40
will always have the same color for the bottom two-thirds of their helmets.
The only driver this affects among the default drivers is #15 Mauricio Gugelmin,
who has a helmet that is mostly dark red anyway.

However, if you use a <a href="/argeditor/decompressed-exe/">decompressed EXE</a>
these limitations go away.

When editing one of these helmets, a message will be displayed, reminding you that it
will not export in the way you have painted it unless you are using a decompressed EXE file.


## Points System tab

This is where you set the number of points each finishing position scores for
the championship.

<img alt="Points System tab" src="/argeditor/images/points-system.png" />

You can edit the number of points scored for each finishing position, from 1st down
to 26th. However, to award points to finishers in position 7th to 26th you need to
use a <a href="/argeditor/decompressed-exe/">decompressed EXE</a>.

The maximum number of points that a finish can score is 255. Another thing to note
is that drivers that do not finish the races do not receive any points at all,
even if the position they end up in would have been a scoring one.

On the right is a number of buttons with presets for the F1 points scoring systems
used since the beginning of the 1960s. Click on a button to update the screen
with the specified system's points.

If you award points to positions 7th to 26th, a message will appear that informs
you that they will only be available if using a decompressed EXE file.


## I have finished my car set, now what?

After you have created the car set you can either save it to disk, either as an F1Ed .1ed file,
or as an ArgEditor .arged file.

Note that if you save it as a legacy F1Ed file, the points system you have entered will not
be saved, since F1Ed has no support for editing that.

You can also <a href="/argeditor/importing-and-exporting/#exporting-data">export</a>
the car set to a GP.EXE file of your choice.
