﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayMeshAs2D : MonoBehaviour
{
    //we can import any model in .obj, import it as unity prefab and get a reference in editor
    [SerializeField]
    private GameObject rabbit;
    [SerializeField]
    private GameObject monkey;
    [SerializeField]
    private GameObject sphere;

    //gameobject with components used to draw the lines
    [SerializeField]
    private GameObject drawingGO;
    [SerializeField]
    private Vector3 screenOffset;


    public void DrawMesh(GameObject selectedGO)
    {
        //create instance of object used to draw the mesh
        GameObject drawerInstance=Instantiate(drawingGO);
        //move it by screen offset
        drawerInstance.transform.position += screenOffset;
        //get the refrence of LineRenderer compomnent used to draw the lines
        LineRenderer lr = drawerInstance.GetComponent<LineRenderer>();
        Mesh mesh = selectedGO.GetComponentInChildren<MeshFilter>().sharedMesh;
        if (mesh == null)
        {
            return;
        }
        //we can get the list vertices(vector3) from mesh component of any imported model 
        List<Vector3> vertices = new List<Vector3>();
        mesh.GetVertices(vertices);
        //same for one dimensional array of triangles, three elements of this array form one triangle
        int[] triangles =mesh.triangles;
        //set the number of points we use to generate lines
        lr.positionCount = triangles.Length;
        //iterate throught triangles and draw lines between points
        for (int i = 0; i < triangles.Length; i++)
        {
            Vector3 pointToAdd = vertices[triangles[i]];
            pointToAdd.z = 0;
            lr.SetPosition(i,pointToAdd);
        }
        //move the simple screen offset
        screenOffset += Vector3.right * 4;
        //set the text under the rendered object to be equal to the name of the model
        drawerInstance.GetComponentInChildren<TMP_Text>().text = selectedGO.name;
    }
    //run our code
    private void Start()
    {
        DrawMesh(sphere);
        DrawMesh(rabbit);
        DrawMesh(monkey);
    }
}