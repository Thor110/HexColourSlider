# Hex Colour Slider

I made this program to determine float32 values as hexadecimal in order to identify values that are needed for changing the colours of gui elements when hexediting the executable for Star Wars Knights of the Old Republic II : The Sith Lords

As outlined in my tutorial here : https://deadlystream.com/topic/6886-tutorial-kotor-modding-tutorial-series/

Tutorial : 24 - [ADVANCED] - Hard Coded GUI Elements

It's wildly inefficient, having all the calculations done within a single method.

I did it this way to see if I could make all of the controls use a single method.

I also tried to make sure that it only updated the relevant controls, there is only a single line of duplicate code.

It does however update the PictureBox colours every time it runs.