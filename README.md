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
![alt text](https://github.com/Zuvix/Fogip/blob/main/1.PNG?raw=true)
Only .obj files can be loaded and after loading a correct file, the application will display the wireframe mesh, the Y-axis of model directs upwards and X-axis directs right. (Z is ignored). 

![alt text](https://github.com/Zuvix/Fogip/blob/main/2.PNG?raw=true)

After model is displayed a user can use use Scale, Rotation and Translation options to perform desired transormations. All the transformations are performed in localSpace of an object. 
* Before each transformation the object is moved into global center. 
* Then the transformation is calculated. 
* Object is moved to previous point(new translation is taken into account). 
* At last the object is transformed into projection view . 

![alt text](https://github.com/Zuvix/Fogip/blob/main/5.PNG?raw=true)

Between each transformation an animation occurs where the user can see details of most recently performed transformation. Model before transformations.

![alt text](https://github.com/Zuvix/Fogip/blob/main/3.PNG?raw=true)

Model after performing Translate, Scale and Rotate Transformations.

![alt text](https://github.com/Zuvix/Fogip/blob/main/4.PNG?raw=true)

# Stage 3
In stage 3 we remade the visualisation from wireframe model to filled triangles. In oreder to do that we had to use Unity Mesh component instead of Line renderer. We also had to make a simple Shader to generate a material that won't react to default Unity Engine lighting and with exposed color so we can change it in scripts. Class **Triangle** is used to represent a single triangle mesh with the custom material. The triangle meshes are stored in **IndexedFace** class that is responsible for managing all model data(vertices, indices..). 

Our next task was to implement Backface culling. We added functions to our **Vect4** Class to perform a Vector *dot product*, *cross product* and to *normalize* vector. Now we had all functions needed to do the culling. For each face we:
1. Calculated the normal normal vector.
2. Performed dot product of normal vector and camera to polygon vector(same for each polygon, see ortographic projections).
3. Based on the result of dot product we hide the back faces.

How user sees the displayed mesh:

![alt text](https://github.com/Zuvix/Fogip/blob/main/7.PNG?raw=true)

We see the results of culling if we move camera in the Unity scene view:

![alt text](https://github.com/Zuvix/Fogip/blob/main/6.PNG?raw=true)

The last job we had to do was to implement two lighting models **Blinn-Phong model** and **Phong model**. We use the models to calculate lighting right after the the culling is performed, only for faces that should be visible. This is impemented in two methods: 

![alt text](https://github.com/Zuvix/Fogip/blob/main/8.PNG?raw=true)

Parameters ka,kd,ks,h and color can be changed using the GUI. 

![alt text](https://github.com/Zuvix/Fogip/blob/main/9.PNG?raw=true)

After playing with the parameters we can get the final result like this:

![alt text](https://github.com/Zuvix/Fogip/blob/main/10.PNG?raw=true)

# Download
To test the application we include zip files with builds for stage 2 and 3. Simply unzip the file and run the VisualiseObjects.exe.

