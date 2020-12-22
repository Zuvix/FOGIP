using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vect4 
{
    public float x;
    public float y;
    public float z;
    public float w;
    public Vect4(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = 1;
    }
    public Vect4(float x, float y, float z, float w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }
    public Vect4(string x, string y, string z)
    {
        try
        {
            this.x = float.Parse(x, System.Globalization.CultureInfo.InvariantCulture);
            this.y = float.Parse(y, System.Globalization.CultureInfo.InvariantCulture);
            this.z = float.Parse(z, System.Globalization.CultureInfo.InvariantCulture);
            this.w = 1;
        }
        catch (FormatException)
        {
            Debug.LogError("string to vect4 failded, invalid arguments: "+x+" "+y+ " " + z);
        }

    }
    public Vect4(Vector3 unityVector)
    {
        this.x = unityVector.x;
        this.y = unityVector.y;
        this.z = unityVector.z;
        this.w = 1;
    }

}
