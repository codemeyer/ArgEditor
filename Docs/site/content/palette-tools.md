---
title: "ArgEditor: Palette Tools"
---

# Palette Tools

<p>
    The palette tool consists of four buttons, which indicate its current mode, and a palette of
    256 colors. The currently selected color in the palette has a red outline, and it also appears
    in the rectangle below the palette.
</p>
<p>
    <img alt="Palette tools" src="/argeditor/images/palette-tools.png" class="img-fluid" />
</p>


<h2 id="modes">Modes</h2>

<p>
    There are four different modes to the palette.
</p>

<h3 id="fill">Fill</h3>
<p>
    The default mode, where clicking on a paintable panel will fill it with the selected color in the palette.
</p>

<h3 id="pickup">Pickup</h3>
<p>
    When this mode is active, clicking on a panel will select its color in the palette. For instance, if you
    have a color on the car that you want to paint another panel with, you would select the <em>Pickup</em> tool,
    click the panel, then switch over to <em>Fill</em> mode and click the panel that you want to paint.
</p>

<h3 id="darken">Darken</h3>
<p>
    With this mode active, clicking on a panel will paint it with the next darker color available in the palette.
    If there is no darker color, nothing will happen.
</p>

<h3 id="brighten">Brighten</h3>
<p>
    With this mode active, clicking on a panel will paint it with the next brighter color available in the palette.
    If there is no brighter color, nothing will happen.
</p>


<h2 id="keyboard-shortcuts">Keyboard shortcuts</h2>

<p>
    When you are on the Cars or Helmets tab, you can use the + and - keys to select the
    next brighter (+) or next darker (-) color in the palette.
</p>


<h2 id="notes">Notes</h2>

If you select any color from the second row from the top (the row where the left half of the colors
are green and the right ones are gray) then ArgEditor will display a little warning at the bottom.
This is because those colors may be slightly brighter or darker at different tracks, depending on
how the specific track adjusts the grass and asphalt colors.

For example, Magny-Cours has a much darker asphalt color than most other tracks.

There is also a group of blue colors that will display a warning that these colors turn gray
a lot during wet races. For the default cars, you may have noticed this behavior for the Leyton House cars.
