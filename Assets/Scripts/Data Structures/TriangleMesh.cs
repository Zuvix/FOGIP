using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class used to draw a single triangle filled with color
public class TriangleMesh : MonoBehaviour
{
    Mesh mesh;
    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();
        mesh.vertices = new Vector3[] { new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(1, 1, 0) };
        //mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };
        mesh.triangles = new int[]{0, 1, 2};
    }

    public void DrawTriangle(Vect4 a, Vect4 b, Vect4 c)
    {
        mesh.Clear();
        mesh.vertices = new Vector3[] { a.Convert(), b.Convert(), c.Convert() };
        mesh.triangles = new int[] { 0, 1, 2 };
    }

    // Update is called once per frame
}
