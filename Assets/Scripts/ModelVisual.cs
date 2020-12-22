using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ModelVisual : MonoBehaviour
{
    [SerializeField]
    private GameObject drawingGO;
    [SerializeField]
    private Vector3 screenOffset;
    public GameObject activeModel;
    List<IndexedFace> drawedTriangles;
    public void DrawMesh(string name,List<Vect4> vertices, List<int> indices)
    {
        if (activeModel != null)
        {
            Destroy(activeModel);
            drawedTriangles = new List<IndexedFace>();
        }
        activeModel = new GameObject("Model");
        activeModel.transform.position += screenOffset;
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
            drawedTriangles.Add(new IndexedFace(i / 3,lr, p1, p2, p3));
        }
    }
    public void ApplyTranslation(Vect4 translationVector)
    {
        //Create matrix
        Mat4 transformationMatrix = new Mat4(MatType.translation, translationVector);
        foreach (IndexedFace triangle in drawedTriangles)
        {
            Vect4[] points = triangle.GetPoints();
            for(int i=0;i<3;i++)
            {
                Vect4 translatedPoint = transformationMatrix.Multiply(points[i]);
                triangle.UpdatePoint(i, translatedPoint);
            }
            triangle.UpdateLine();
        }
    }
}
