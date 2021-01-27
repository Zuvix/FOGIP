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

    public Triangle CreateTriangle(Vect4 p1, Vect4 p2, Vect4 p3)
    {
        mesh = GetComponent<MeshFilter>().mesh;
        mr = GetComponent<MeshRenderer>();
        mesh.Clear();
        this.currentPoints[0] = p1;
        this.currentPoints[1] = p2;
        this.currentPoints[2] = p3;
        mesh.vertices = new Vector3[] { p1.Convert(), p2.Convert(), p3.Convert() };
        mr.material.SetColor("_Color", Color.gray* Random.Range(0, 1f));
        mesh.triangles = new int[] { 0, 1, 2 };
        //BackFaceCulling(finalPoints[0], finalPoints[1],finalPoints[2]);

        return this;
    }
    //Display the face on screen
    public void UpdateLines()
    {
        mesh.Clear();
        mesh.vertices = new Vector3[] { new Vector3(finalPoints[0].x, finalPoints[0].y, finalPoints[0].z), new Vector3(finalPoints[1].x, finalPoints[1].y, finalPoints[1].z), new Vector3(finalPoints[2].x, finalPoints[2].y, finalPoints[2].z) };
        mesh.triangles = new int[] { 0, 1, 2 };
        mr.enabled = true;
        BackFaceCulling(finalPoints[0], finalPoints[1],finalPoints[2]);
    }
    //Display the face, by slowly animating from last transformation
    /*public void TweenLines()
    {
        DOTween.To(() => lr.GetPosition(0), (x) => lr.SetPosition(0, x), new Vector3(finalPoints[0].x, finalPoints[0].y, 0), 2).Play();
        DOTween.To(() => lr.GetPosition(3), (x) => lr.SetPosition(3, x), new Vector3(finalPoints[0].x, finalPoints[0].y, 0), 2).Play();
        DOTween.To(() => lr.GetPosition(1), (x) => lr.SetPosition(1, x), new Vector3(finalPoints[1].x, finalPoints[1].y, 0), 2).Play();
        DOTween.To(() => lr.GetPosition(2), (x) => lr.SetPosition(2, x), new Vector3(finalPoints[2].x, finalPoints[2].y, 0), 2).Play();
    }*/
    //Update point for view
    public void BackFaceCulling(Vect4 p1, Vect4 p2,Vect4 p3)
    {
        Vect4 normal;
        normal = p1.CrossProduct(p2.Substraction(p1), p3.Substraction(p1));
        normal=normal.Normalize();
        if (normal.DotProduct(normal, new Vect4(0, 0, 1))>=0)
        {
            mr.enabled = false;
            Debug.Log(normal.x + "  " + normal.y + "  " + normal.z);
            Debug.Log(normal.DotProduct(normal, new Vect4(0, 0, 1)));
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
