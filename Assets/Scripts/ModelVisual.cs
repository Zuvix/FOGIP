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

    public void DrawMesh(string name,List<Vect4> vertices, List<int> triangles)
    {
        if (activeModel != null)
        {
            Destroy(activeModel);
        }
        activeModel = new GameObject("Model");
        activeModel.transform.position += screenOffset;
        for (int i = 0; i < triangles.Count; i += 3)
        {
            GameObject drawerInstance = Instantiate(drawingGO, activeModel.transform);
            LineRenderer lr = drawerInstance.GetComponent<LineRenderer>();
            lr.positionCount = 3;

            Vect4 pointToAdd = vertices[triangles[i]-1];
            lr.SetPosition(0, new Vector3(pointToAdd.x, pointToAdd.y, 0));

            pointToAdd = vertices[triangles[i + 1]-1];
            lr.SetPosition(1, new Vector3(pointToAdd.x, pointToAdd.y, 0));

            pointToAdd = vertices[triangles[i + 2]-1];
            lr.SetPosition(2, new Vector3(pointToAdd.x, pointToAdd.y, 0));

        }
    }
}
