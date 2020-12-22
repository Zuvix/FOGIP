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
        Mat4 translationMatrix = new Mat4(MatType.translation, translationVector);
        modelVisual.ApplyTransformation(translationMatrix);
    }
    public void Scale()
    {
        Vect4 scalingVector = UiControl.GetScalingVector();
        Mat4 scalingMatrix = new Mat4(MatType.scale, scalingVector);
        modelVisual.ApplyTransformation(scalingMatrix);
    }
    public void Rotate()
    {
        Vect4 rotationVector = UiControl.GetRotationVector();
        Mat4 rotxMatrix = new Mat4(MatType.rotx,rotationVector.x);
        modelVisual.ApplyTransformation(rotxMatrix);

        Mat4 rotyMatrix = new Mat4(MatType.roty, rotationVector.y);
        modelVisual.ApplyTransformation(rotyMatrix);

        Mat4 rotzMatrix = new Mat4(MatType.rotz, rotationVector.z);
        modelVisual.ApplyTransformation(rotzMatrix);
    }

}
