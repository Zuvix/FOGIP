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

# Stage 2
In stage 2 we improved the Loading of .obj files. Now we can manualy select a .obj file from anywhere in our file system and read the file while storing important data into defined data structures such as Vect4 and IndexedFaces.
![alt text](https://github.com/Zuvix/Fogip/blob/main/1.png?raw=true)
Only .obj files can be loaded and after loading a correct file, the application will display the wireframe mesh, the Y-axis of model directs upwards and X-axis directs right. (Z is ignored). 
![alt text](https://github.com/Zuvix/Fogip/blob/main/2.png?raw=true)
After model is displayed a user can use use Scale, Rotation and Translation options to perform desired transormations. All the transformations are performed in localSpace of an object. Object is transformed into projection view after each local transformation. Between each transformation an animation occurs where the user can see details of most recently performed transformation. Model before transformations.
![alt text](https://github.com/Zuvix/Fogip/blob/main/3.png?raw=true)
Model after performing Translate, Scale and Rotate Transformations.
![alt text](https://github.com/Zuvix/Fogip/blob/main/4.png?raw=true)

# Downloading the build
There is a zipped file containing the build of an application. Simply download, unzip and run the Display Mesh.exe file.

