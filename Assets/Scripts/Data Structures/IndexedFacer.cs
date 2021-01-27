using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexedFacer : Singleton<IndexedFacer>
{
    public GameObject MeshPrefab;
    private List<int> loadedIndices;
    private List<Vect4> loadedVertices;
    public Vect4[] currentPoints = new Vect4[3];

    List<TriangleMesh> renderedPolygons;
    private void Awake()
    {
        renderedPolygons = new List<TriangleMesh>();

    }
    public void LoadDataIntoMeshes()
    {
        TriangleMesh tm = Instantiate(MeshPrefab).GetComponent<TriangleMesh>();
        
    }
}
