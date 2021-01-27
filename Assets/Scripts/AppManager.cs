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
    public float ka= 0.2f;
    public float kd=0.4f;
    public float ks=0.3f;
    public float h=2;
    public Color materialColor = Color.grey;
    public Vect4 light=new Vect4(0,1,0).Normalize();
    public string lightType = "Blinn";

    public void UpdateModel(string path, string name)
    {
        FileManager.RetriveModelData(path,out loadedVertices, out loadedIndices);
        modelVisual.DrawMesh(name, loadedVertices, loadedIndices);
    }

    public void ResetModel()
    {
        ka = 0.2f;
        kd = 0.4f;
        ks = 0.3f;
        h = 2;
        materialColor = Color.grey;
        light = new Vect4(0, 1, 0).Normalize();
        lightType = "Blinn";
        modelVisual.ResetLocalCenter();
        modelVisual.DrawMesh(name, loadedVertices, loadedIndices);

    }
    public void Redraw()
    {
        modelVisual.RedrawModel();
    }
    public void Translate()
    {
        Vect4 translationVector = UiControl.GetTranslationVector();
        Mat4 translationMatrix = new Mat4(MatType.translation, translationVector);
        modelVisual.ApplyTransformation(translationMatrix,true);
        modelVisual.ChangeLocalCenter(translationVector);
    }

    public void Scale()
    {
        Vect4 scalingVector = UiControl.GetScalingVector();
        Mat4 scalingMatrix = new Mat4(MatType.scale, scalingVector);
        modelVisual.ApplyTransformation(scalingMatrix,true);
    }

    public void Rotate()
    {
        //We apply rotation one by one starting with X
        Vect4 rotationVector = UiControl.GetRotationVector();
        Mat4 rotxMatrix = new Mat4(MatType.rotx,rotationVector.x);
        modelVisual.ApplyTransformation(rotxMatrix, true);

        Mat4 rotyMatrix = new Mat4(MatType.roty, rotationVector.y);
        modelVisual.ApplyTransformation(rotyMatrix,true);

        Mat4 rotzMatrix = new Mat4(MatType.rotz, rotationVector.z);
        modelVisual.ApplyTransformation(rotzMatrix,true);
    }

}
