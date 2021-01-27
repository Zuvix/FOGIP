using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Triangle: MonoBehaviour
{
    Mesh mesh;
    MeshRenderer mr;
    public Vect4[] currentPoints = new Vect4[3];
    
    //used for animation and visualisation of faces
    //final meaning after multiplying with projection matrix
    private Vect4[] finalPoints = new Vect4[3];
    private LineRenderer lr;
    Vect4 normal;

    public Triangle CreateTriangle(Vect4 p1, Vect4 p2, Vect4 p3)
    {
        mesh = GetComponent<MeshFilter>().mesh;
        mr = GetComponent<MeshRenderer>();
        mesh.Clear();
        this.currentPoints[0] = p1;
        this.currentPoints[1] = p2;
        this.currentPoints[2] = p3;
        mesh.vertices = new Vector3[] { p1.Convert(), p2.Convert(), p3.Convert() };
        mesh.triangles = new int[] { 0, 1, 2 };
        //BackFaceCulling(finalPoints[0], finalPoints[1],finalPoints[2]);

        return this;
    }
    //Display the face on screen
    public void RedrawTriangle()
    {
        mesh.Clear();
        mesh.vertices = new Vector3[] { new Vector3(finalPoints[0].x, finalPoints[0].y, finalPoints[0].z), new Vector3(finalPoints[1].x, finalPoints[1].y, finalPoints[1].z), new Vector3(finalPoints[2].x, finalPoints[2].y, finalPoints[2].z) };
        mesh.triangles = new int[] { 0, 1, 2 };
        mr.enabled = true;
        CalculateNormal(finalPoints[0], finalPoints[1], finalPoints[2]);
        BackFaceCulling(finalPoints[0], finalPoints[1],finalPoints[2]);
        CalculateLight(AppManager.Instance.light, new Vect4(0, 0, -1), AppManager.Instance.ka, AppManager.Instance.kd, AppManager.Instance.ks, AppManager.Instance.h);
    }
    public void CalculateNormal(Vect4 p1, Vect4 p2, Vect4 p3)
    {
        normal = p1.CrossProduct(p2.Substraction(p1), p3.Substraction(p1));
        normal = normal.Normalize();
    }
    public void BackFaceCulling(Vect4 p1, Vect4 p2,Vect4 p3)
    {
        if (normal.DotProduct(normal, new Vect4(0, 0, 1))>=0)
        {
            //Dont draw triangle
            mr.enabled = false;
        } 
    }
    public void CalculateLight(Vect4 light, Vect4 view,float ka, float kd, float ks, float h)
    {
        //Check if face is visible
        if (mr.enabled == true)
        {
            float Ia = ka * 1;
            float Id = normal.DotProduct(normal,light);
            Vect4 H = view.Addition(light);
            H.Normalize();
            float Is = Mathf.Pow(H.DotProduct(H, normal),h); 
            float I = Ia+Id+Is;
            mr.material.SetColor("_Color", Color.gray * I/3);
            Debug.Log(I);
        }
    }
    public void UpdateFinalPoint(int index, Vect4 point)
    {
        finalPoints[index] = point;
    }
    //Update local point
    public void UpdateLocalPoint(int index, Vect4 point)
    {
        currentPoints[index] = point;
    }
    public Vect4[] GetCurrentPoints()
    {
        return currentPoints;
    }
}
