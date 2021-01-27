using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ModelVisual : MonoBehaviour
{
    [SerializeField]
    private GameObject drawingGO;
    [SerializeField]
    public GameObject activeModel;
    public GameObject trianglePrefab;
    //we store a list of drawed triangles so we can modify them during runtime
    private List<Triangle> drawedTriangles;
    private Vect4 localCenter=new Vect4(0,0,0);
    public void DrawMesh(string name,List<Vect4> vertices, List<int> indices)
    {
        if (activeModel != null)
        {
            Destroy(activeModel);
            drawedTriangles = new List<Triangle>();
        }
        activeModel = new GameObject(name);
        for (int i = 0; i < indices.Count; i += 3)
        {

            Vect4 p1 = vertices[indices[i]-1];
            Vect4 p2 = vertices[indices[i + 1]-1];
            Vect4 p3 = vertices[indices[i + 2]-1];
            drawedTriangles.Add(Instantiate(trianglePrefab, activeModel.transform).GetComponent<Triangle>().CreateTriangle(p1,p2,p3));
        }
        //We apply this transformation just to get the object to view
        ApplyTransformation(new Mat4(MatType.identity),false);
    }

    public void ApplyTransformation(Mat4 transformationMatrix, bool shouldAnimate)
    {
        //First we move object to global center 0,0,0
        TranslateToGlobalCenter();
        //Then we Perform transformation
        foreach (Triangle face in drawedTriangles)
        {
            Vect4[] points = face.GetCurrentVertices();
            for (int i = 0; i < 3; i++)
            {
                //apply transformation to current point
                Vect4 CurrentPoint = transformationMatrix.Multiply(points[i]);
                //update the current point
                face.UpdateVertex(i, CurrentPoint);
            }
        }
        //Now we move object back to local point
        TranslateToLocalCenter();
        //Draw it <- includes calculating light and backface culling
        foreach (Triangle face in drawedTriangles)
        {
            if (shouldAnimate)
            {
                //TODO ANIMATE
                face.RedrawTriangle();
            }
            else
            {
                face.RedrawTriangle();
            }
            //simply display object or animate the transformation

        }
    }
    public void TranslateToGlobalCenter()
    {
        if(localCenter.x!=0 || localCenter.y!=0 || localCenter.z != 0)
        {
            Debug.Log("Moving to global center");
            Mat4 translationMatrix = new Mat4(MatType.translation, localCenter.Invert());
            foreach (Triangle face in drawedTriangles)
            {
                //get the Vertices 
                Vect4[] points = face.GetCurrentVertices();
                for (int i = 0; i < 3; i++)
                {
                    //move point to globalCenter

                    //apply transformation to current vertex
                    Vect4 CurrentPoint = translationMatrix.Multiply(points[i]);

                    //update the current vertex
                    face.UpdateVertex(i, CurrentPoint);
                }
            }
        }
        
    }

    public void TranslateToLocalCenter()
    {
        if (localCenter.x != 0 || localCenter.y != 0 || localCenter.z != 0)
        {
            Debug.Log("Moving to local center");
            Mat4 translationMatrix = new Mat4(MatType.translation, localCenter);
            foreach (Triangle face in drawedTriangles)
            {
                //get the Vertices
                Vect4[] points = face.GetCurrentVertices();
                for (int i = 0; i < 3; i++)
                {

                    //apply transformation to current vertex
                    Vect4 CurrentPoint = translationMatrix.Multiply(points[i]);

                    //update the current vertex
                    face.UpdateVertex(i, CurrentPoint);
                }
            }
        }
    }
    public void ChangeLocalCenter(Vect4 translation)
    {
        localCenter = localCenter.Addition(translation);
    }
    public void RedrawModel()
    {
        foreach (Triangle face in drawedTriangles)
        {
            face.RedrawTriangle();
        }
    }

    public void ResetLocalCenter()
    {
        localCenter = new Vect4(0, 0, 0);
    }
}
