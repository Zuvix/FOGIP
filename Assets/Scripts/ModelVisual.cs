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
    //we store a list of drawed faces so we can modify them during runtime
    private List<IndexedFace> drawedFaces;
    private Vect4 localCenter=new Vect4(0,0,0);
    public void DrawMesh(string name,List<Vect4> vertices, List<int> indices,Mat4 projectionMatrix)
    {
        if (activeModel != null)
        {
            Destroy(activeModel);
            drawedFaces = new List<IndexedFace>();
        }
        activeModel = new GameObject(name);
        for (int i = 0; i < indices.Count; i += 3)
        {
            GameObject drawerInstance = Instantiate(drawingGO, activeModel.transform);
            LineRenderer lr = drawerInstance.GetComponent<LineRenderer>();
            lr.positionCount = 4;

            Vect4 p1 = vertices[indices[i]-1];
            lr.SetPosition(0, new Vector3(p1.x, p1.y, 0));
            lr.SetPosition(3, new Vector3(p1.x, p1.y, 0));

            Vect4 p2 = vertices[indices[i + 1]-1];
            lr.SetPosition(1, new Vector3(p2.x, p2.y, 0));

            Vect4 p3 = vertices[indices[i + 2]-1];
            lr.SetPosition(2, new Vector3(p3.x, p3.y, 0));
            
            //We might need the indices later when searching for neighbours
            int[] pointIndices = new int[3];
            pointIndices[0] = indices[i] - 1;
            pointIndices[1] = indices[i + 1] - 1;
            pointIndices[2] = indices[i + 2] - 1;
            //Add to our array of faces
            drawedFaces.Add(new IndexedFace(lr, p1, p2, p3, pointIndices));
        }
        //We apply this transformation just to get the object to view
        ApplyTransformation(new Mat4(MatType.identity), projectionMatrix,false);
    }

    public void ApplyTransformation(Mat4 transformationMatrix, Mat4 projectionMatrix, bool shouldAnimate)
    {
        TranslateToGlobalCenter();
        //Perform transformation
        foreach (IndexedFace face in drawedFaces)
        {
            Vect4[] points = face.GetCurrentPoints();
            for (int i = 0; i < 3; i++)
            {
                //apply transformation to local point
                Vect4 LocalPoint = transformationMatrix.Multiply(points[i]);

                //update the current point
                face.UpdateLocalPoint(i, LocalPoint);
                //multiply by projection matrix
                Vect4 FinalPoint = projectionMatrix.Multiply(LocalPoint);
                face.UpdateFinalPoint(i, FinalPoint);
            }
        }
        TranslateToLocalCenter();
        //Transform into view
        foreach (IndexedFace face in drawedFaces)
        {
            Vect4[] points = face.GetCurrentPoints();
            for (int i = 0; i < 3; i++)
            {
                //Transform to projection matrix
                Vect4 FinalPoint = projectionMatrix.Multiply(points[i]);
                face.UpdateFinalPoint(i, FinalPoint);
            }
            //simply display or animate the object
            if (shouldAnimate)
            {
                face.TweenLines();
            }
            else
            {
                face.UpdateLines();
            }
        }
        

    }
    public void TranslateToGlobalCenter()
    {
        if(localCenter.x!=0 || localCenter.y!=0 || localCenter.z == 0)
        {
            Debug.Log("Moving to global center");
            Mat4 translationMatrix = new Mat4(MatType.translation, localCenter.Invert());
            foreach (IndexedFace face in drawedFaces)
            {
                //get the local points of one face
                Vect4[] points = face.GetCurrentPoints();
                for (int i = 0; i < 3; i++)
                {
                    //move point to globalCenter

                    //apply transformation to current point
                    Vect4 CurrentPoint = translationMatrix.Multiply(points[i]);

                    //update the current point
                    face.UpdateLocalPoint(i, CurrentPoint);
                }
            }
        }
        
    }

    public void TranslateToLocalCenter()
    {
        if (localCenter.x != 0 || localCenter.y != 0 || localCenter.z == 0)
        {
            Debug.Log("Moving to local center");
            Mat4 translationMatrix = new Mat4(MatType.translation, localCenter);
            foreach (IndexedFace face in drawedFaces)
            {
                //get the local points of one face
                Vect4[] points = face.GetCurrentPoints();
                for (int i = 0; i < 3; i++)
                {
                    //move point to globalCenter

                    //apply transformation to current point
                    Vect4 CurrentPoint = translationMatrix.Multiply(points[i]);

                    //update the current point
                    face.UpdateLocalPoint(i, CurrentPoint);
                }
            }
        }
    }
    public void ChangeLocalCenter(Vect4 translation)
    {
        localCenter = localCenter.Addition(translation);
    }
}
