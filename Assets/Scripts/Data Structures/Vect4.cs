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
            if (x.Length > 0)
            {
                this.x = float.Parse(x.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                this.x = 0;
            }
            if (y.Length > 0)
            {
                this.y = float.Parse(y.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                this.y = 0;
            }
            if (z.Length > 0)
            {
                this.z = float.Parse(z.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                this.z = 0;
            }
            this.w = 1;
        }
        catch (FormatException)
        {
            Debug.LogError("string to vect4 failded, invalid arguments: "+x+" "+y+ " " +z);
        }

    }
}
