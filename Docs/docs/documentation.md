# Documentation

The tabs at the top have something of a natural order to them. In the first,
you enter the teams and drivers, on the second tab you set their performance,
on the third you paint the cars and pit crews, and on the fourth and last
tab you paint the drivers' helmets.


## Teams and drivers

This is where you enter team names and their engines, one or two drivers for
each team. You must also set a number for the driver, where the numbers available
range from 1 to 40.

![Teams and drivers tab screenshot](img/teams-and-drivers.png)

A team can be disabled by emptying its name and engine. A driver can be disabled
by emptying their name.

There must be at least 26 active drivers. Two drivers cannot have the same numbers.

Note that the first team in the list has a different car shape than the other
teams. This was to make the McLaren have the well-known Marlboro paint scheme
with a red diagonal stripe across the nose cone. So if you are making a car set
that does not feature a classic McLaren paint scheme, it would be advisable to
leave the first team empty, and also skip the second theme for nicer symmetry
on the F1GP driver selection screen.


## Performance

![Performance tab screenshot](img/performance.png)

Horsepower values determine how fast the cars will be, where higher is better.

Drivers have two grip levels, one for qualifying and one for the race. A lower
grip level value means better grip, so think of the value you are setting as
a grip level "penalty".

On the right you will see a rough estimate of how drivers will perform relative
to each other. These values are based on data collected for drivers at the
Silverstone track, which was chosen because of its mix of straights and different
corners. At high speed tracks like Hockenheim and Monza, the horsepower value
will have a much greater effect on the lap times. At the opposite end of the
spectrum, lap times at Monaco will be much more influenced by the grip level
of the drivers.

### Suitable values

In F1GP, teams have horsepower values ranging from 716 at the top to 610 at the
bottom. Drivers have their grip levels in order, from 1 at the top to 34 at
the bottom.

Grip level penalties can be set as high as 255, but then the driver will just
trundle along the track, sliding like a drift racer. I would not recommend
going above 50.

### Performance levels and qualifying sessions

A thing to note is that when you completely skip the qualifying session in
F1GP, the grid that the game sets up for you is _only_ based on the horsepower
value of the car, and not at all by the grip level. Therefore, skipping the
qualifying session will remove any performance differences you have set between
team-mates.


## Cars

This is where you paint cars and pit crews.

![Cars tab screenshot](img/cars.png)

Click on a car in the left part of the screen to paint it. Painting is done by
selecting a color in the palette and then clicking a panel that you want to paint
on the large car above the palette.

The same applies for painting the pit crew.

As noted above in the Teams and Drivers section, the first car - McLaren in
the default game - has a slightly different panel layout on the nose.


## Helmets

Here is where you paint driver helmets.

![Settings tab screenshot](img/helmets.png)

The selection and painting works in the same way as in the Cars tab.


### Helmets behaving differently

Presumably for optimization reasons, some helmets in the game have fewer colors
available to them. Helmets for drivers with #13, #15, #36, #37, #38, #39 and #40
will always have the same color for the bottom two-thirds of their helmets.
The only driver this affects among the default drivers is #15 Mauricio Gugelmin,
who has a helmet that is mostly dark red anyway.

When editing one of these helmets and clicking one of the affected stripes, the
other stripes will be painted as well.


## Game Settings

By clicking on the cogwheel on the left, you get to the game settings screen.

![Settings tab screenshot](img/helmets.png)

Currently, the only thing you can edit here is the horsepower value that
the player's (that is you!) car will have. The default value is 716, just like
the top teams.


## Open and Save

The File menu at the top of the screen lets you open and save car sets.


## Import and Export

When are finished naming and painting, you can export everything to an
existing GP.EXE file. From the File menu, choose Export. When exporting,
names are not automatically included. You will need to export a name file
and then load the name file in-game. (ArgEditor will let you handle this more smoothly soon...)

It is better to be save than sorry! Backup your GP.EXE and other files before
exporting. You would probably want to export to a copy of the original anyway...

You can also import data from EXEs or name files.
