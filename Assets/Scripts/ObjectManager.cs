using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : Singleton<ObjectManager>
{
    private List<int> loadedIndices;
    private List<Vect4> loadedVertices;
    public ModelVisual modelVisual;
    public UiControl UiControl;
    public void UpdateModel(string path, string name)
    {
        FileManager.RetriveModelData(path,out loadedVertices, out loadedIndices);
        modelVisual.DrawMesh(name, loadedVertices, loadedIndices);
    }
    public void ResetModel()
    {
        modelVisual.DrawMesh(name, loadedVertices, loadedIndices);
    }
    public void Translate()
    {
        Vect4 translationVector = UiControl.GetTranslationVector();
        modelVisual.ApplyTranslation(translationVector);
    }

}
