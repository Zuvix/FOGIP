using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : Singleton<AppManager>
{
    private List<int> loadedIndices;
    private List<Vect4> loadedVertices;
    private List<Triangle> indexedFaces;
    public ModelVisual modelVisual;
    public UiControl UiControl;
    public Mat4 projectionMatrix;
    private void Awake()
    {
        //Setup projection matrix so we get desired projection
        projectionMatrix = new Mat4(MatType.identity);
        // we offset the object to be more in center of screen
        projectionMatrix.members[3, 0] = -1f;
    }

    public void UpdateModel(string path, string name)
    {
        FileManager.RetriveModelData(path,out loadedVertices, out loadedIndices);
        modelVisual.DrawMesh(name, loadedVertices, loadedIndices,projectionMatrix);
    }

    public void ResetModel()
    {
        modelVisual.DrawMesh(name, loadedVertices, loadedIndices, projectionMatrix);
    }

    public void Translate()
    {
        Vect4 translationVector = UiControl.GetTranslationVector();
        Mat4 translationMatrix = new Mat4(MatType.translation, translationVector);
        modelVisual.ApplyTransformation(translationMatrix,projectionMatrix,true);
        modelVisual.ChangeLocalCenter(translationVector);
    }

    public void Scale()
    {
        Vect4 scalingVector = UiControl.GetScalingVector();
        Mat4 scalingMatrix = new Mat4(MatType.scale, scalingVector);
        modelVisual.ApplyTransformation(scalingMatrix, projectionMatrix,true);
    }

    public void Rotate()
    {
        //We apply rotation one by one starting with X
        Vect4 rotationVector = UiControl.GetRotationVector();
        Mat4 rotxMatrix = new Mat4(MatType.rotx,rotationVector.x);
        modelVisual.ApplyTransformation(rotxMatrix, projectionMatrix,true);

        Mat4 rotyMatrix = new Mat4(MatType.roty, rotationVector.y);
        modelVisual.ApplyTransformation(rotyMatrix, projectionMatrix,true);

        Mat4 rotzMatrix = new Mat4(MatType.rotz, rotationVector.z);
        modelVisual.ApplyTransformation(rotzMatrix, projectionMatrix,true);
    }

}
