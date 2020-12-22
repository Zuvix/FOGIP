using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiControl : MonoBehaviour
{
    public TMP_InputField txTxt;
    public TMP_InputField tyTxt;
    public TMP_InputField tzTxt;
    public Vect4 GetTranslationVector()
    {
        Vect4 translationVector = new Vect4(txTxt.text, tyTxt.text, tzTxt.text);
        return translationVector;
    }

}
