using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : Singleton<ObjectManager>
{
    private List<int> indices;
    private List<Vect4> vertices;
    public ModelVisual modelVisual;  
    public void UpdateModel(string path, string name)
    {
        FileManager.RetriveModelData(path,out vertices,out indices);
        modelVisual.DrawMesh(name,vertices, indices);
    }

}
