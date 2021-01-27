using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiControl : MonoBehaviour
{
    public TMP_InputField txTxt;
    public TMP_InputField tyTxt;
    public TMP_InputField tzTxt;

    public TMP_InputField sxTxt;
    public TMP_InputField syTxt;
    public TMP_InputField szTxt;

    public TMP_InputField rxTxt;
    public TMP_InputField ryTxt;
    public TMP_InputField rzTxt;

    public TMP_InputField lxTxt;
    public TMP_InputField lyTxt;
    public TMP_InputField lzTxt;

    public TMP_InputField kaTxt;
    public TMP_InputField kdTxt;
    public TMP_InputField ksTxt;
    public TMP_InputField hTxt;
    public TMP_Dropdown colorSeter;

    public TMP_Text modelName;
    public Vect4 GetTranslationVector()
    {

        Vect4 translationVector = new Vect4(txTxt.text, tyTxt.text, tzTxt.text);
        return translationVector;
    }
    public Vect4 GetScalingVector()
    {

        Vect4 scalingVector = new Vect4(sxTxt.text, syTxt.text, szTxt.text);
        return scalingVector;
    }
    public Vect4 GetRotationVector()
    {

        Vect4 rotationVector = new Vect4(rxTxt.text, ryTxt.text, rzTxt.text);
        return rotationVector;
    }
    public void SetLightPosition()
    {
        IndexedFace.Instance.light = new Vect4(lxTxt.text, lyTxt.text, lzTxt.text).Normalize();
        IndexedFace.Instance.Redraw();
    }
    public void SetLightProperties()
    {
        if (kaTxt.text.Length > 0)
            IndexedFace.Instance.ka = float.Parse(kaTxt.text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
        else
            IndexedFace.Instance.ka = 0;

        if (kdTxt.text.Length > 0)
            IndexedFace.Instance.kd = float.Parse(kdTxt.text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
        else
            IndexedFace.Instance.kd = 0;

        if (ksTxt.text.Length > 0)
            IndexedFace.Instance.ks = float.Parse(ksTxt.text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
        else
            IndexedFace.Instance.ks = 0;

        if (hTxt.text.Length > 0)
            IndexedFace.Instance.h = float.Parse(hTxt.text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
        else
            IndexedFace.Instance.h = 0;
        IndexedFace.Instance.Redraw();

    }
     public void ChangeColor()
    {
        int val = colorSeter.value;
        if(val== 0)
        {
            IndexedFace.Instance.materialColor = Color.grey;
        }
        if (val == 1)
        {
            IndexedFace.Instance.materialColor = Color.red;
        }
        if (val == 2)
        {
            IndexedFace.Instance.materialColor = Color.blue;
        }
        if (val == 3)
        {
            IndexedFace.Instance.materialColor = Color.green;
        }
    }
    public void SwitchLightModel()
    {
        if (IndexedFace.Instance.lightType.Equals("Blinn"))
        {
            IndexedFace.Instance.lightType = "Phong";
            modelName.text = "Phong model";
        }
        else
        {
            IndexedFace.Instance.lightType = "Blinn";
            modelName.text = "Blinn-Phong";
        }
        IndexedFace.Instance.Redraw();
    }
}
