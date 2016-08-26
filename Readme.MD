#Tetris AR
## About Tetris AR
### AR Changes
- platform is vuforia
- use virtual button to control the game

### How To Use
- print the [imgae target](https://geekgame.bai.uno/geekgame.jpg) or download it to your pad
- apply a vuforia key
- past the key to "App License Key" in ARCamera
- run   ^_^

### Problems
1. *** very important, need another better image target, (already get one, but withou printer, can not print it) to make the buttons more sensitive
2. add audio





Project in Unity3D 5.4, based on the Kaielth folk: https://github.com/Kaielth/Tetris_Remake 

And the original one is from tomgsx: https://github.com/tomgsx/Tetris_Remake


## Features: 

### From Kaielth
 - Simple tetris concept, all tetrominoes falling to bottom, when a row is full then it dissapear and the above rows falls down.
 - Queue for N elements, implemented for up to 3 next pieces
 - Score based on the amount of rows removed at the same time. Points added calculated as N * N, where N is number of rows removed.
 - Speed of the pieces falling increased after certain amount of pieces generated. Speed increased at piece 50, 100, 150, 200 and 250.

### added by Tim
 - audios (blip, gameover ...) and an audio mixer
 - adjust UI (title, score, font), like the screenshot below.
 
![tetris 3d](https://github.com/tim-hub/Tetris_Remake/blob/kaielth-tetris/tetris-3d.PNG)
 