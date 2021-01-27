using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Triangle: MonoBehaviour
{
    //We need to use Unity mesh in order to draw the triangle
    Mesh mesh;
    MeshRenderer mr;
    private Vect4[] vertices = new Vect4[3];
    Vect4 normal;

    public Triangle CreateTriangle(Vect4 p1, Vect4 p2, Vect4 p3)
    {
        mesh = GetComponent<MeshFilter>().mesh;
        mr = GetComponent<MeshRenderer>();
        mesh.Clear();
        this.vertices[0] = p1;
        this.vertices[1] = p2;
        this.vertices[2] = p3;
        mesh.vertices = new Vector3[] { p1.Convert(), p2.Convert(), p3.Convert() };
        mesh.triangles = new int[] { 0, 1, 2 };
        //BackFaceCulling(finalPoints[0], finalPoints[1],finalPoints[2]);

        return this;
    }
    //Display the face on screen
    public void RedrawTriangle()
    {
        mesh.Clear();
        mesh.vertices = new Vector3[] { new Vector3(vertices[0].x, vertices[0].y, vertices[0].z), new Vector3(vertices[1].x, vertices[1].y, vertices[1].z), new Vector3(vertices[2].x, vertices[2].y, vertices[2].z) };
        mesh.triangles = new int[] { 0, 1, 2 };
        mr.enabled = true;
        CalculateNormal(vertices[0], vertices[1], vertices[2]);
        BackFaceCulling(normal, new Vect4(0, 0, 1));
        if (IndexedFace.Instance.lightType.Equals("Blinn"))
        {
            CalculateBlinnPhongLight(IndexedFace.Instance.light, new Vect4(0, 0, -1), IndexedFace.Instance.ka, IndexedFace.Instance.kd, IndexedFace.Instance.ks, IndexedFace.Instance.h);
        }
        else
        {
            CalculatePhongLight(IndexedFace.Instance.light, new Vect4(0, 0, -1), IndexedFace.Instance.ka, IndexedFace.Instance.kd, IndexedFace.Instance.ks, IndexedFace.Instance.h);
        }
    }
    public void CalculateNormal(Vect4 p1, Vect4 p2, Vect4 p3)
    {
        normal = p1.CrossProduct(p2.Substraction(p1), p3.Substraction(p1));
        normal = normal.Normalize();
    }
    public void BackFaceCulling(Vect4 normal, Vect4 view)
    {
        if (normal.DotProduct(normal, view)>=0)
        {
            //Dont draw triangle
            mr.enabled = false;
        } 
    }
    public void CalculateBlinnPhongLight(Vect4 light, Vect4 view,float ka, float kd, float ks, float h)
    {
        //Check if face is visible
        if (mr.enabled == true)
        {
            float Ia = ka * 1;
            float Id = kd*normal.DotProduct(normal,light);
            Vect4 H = view.Addition(light);
            H.Normalize();
            float Is = ks*Mathf.Pow(H.DotProduct(H, normal),h); 
            float I = Ia+Id+Is;
            mr.material.SetColor("_Color", IndexedFace.Instance.materialColor * I);
        }
    }

    public void CalculatePhongLight(Vect4 light, Vect4 view, float ka, float kd, float ks, float h)
    {
        //Check if face is visible
        if (mr.enabled == true)
        {
            float Ia = ka * 1;
            float Id = kd * normal.DotProduct(normal, light);
            //calculate Reflection vector
            //dot product of Light * normal
            float dp = light.DotProduct(normal, light) * 2;
            Vect4 R = new Vect4(normal.x * dp, normal.y * dp, normal.z * dp);
            R = R.Substraction(light);
            R.Normalize();
            float Is = ks * Mathf.Pow(R.DotProduct(R, view), h);
            float I = Ia + Id + Is;
            mr.material.SetColor("_Color", IndexedFace.Instance.materialColor * I);
        }
    }
    public void UpdateFinalPoint(int index, Vect4 point)
    {
        vertices[index] = point;
    }
    //Update local point
    public void UpdateLocalPoint(int index, Vect4 point)
    {
        vertices[index] = point;
    }
    public Vect4[] GetCurrentPoints()
    {
        return vertices;
    }
}
