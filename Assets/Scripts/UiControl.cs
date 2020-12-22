using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

}
