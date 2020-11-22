# FOGIP
Project site:
http://dai.fmph.uniba.sk/w/Course:ZPGSO/en

# Stage 1 
I used Unity Engine to make a simple visualizer for imported meshes. 
Any mesh in .obj can be imported into Unity project and visualsed by a class DisplayMeshAs2D. 
The source code of DisplayMeshAs2D can be found in the /Assets folder. 

One note: The component we used for drawing the lines is not correct, because unwanted lines are present.
It works with 1D array of 3D Vectors, and we can't specify to not draw an edge when moving from one triangle to another. 
We will fix this problem by using a different drawing methond in the next stage.
![alt text](https://github.com/Zuvix/Fogip/blob/main/screen.png?raw=true)
