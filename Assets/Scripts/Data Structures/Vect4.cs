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
    public Vect4 Addition(Vect4 toAddVect)
    {
        Vect4 result = new Vect4(this.x, this.y, this.z);
        result.x += toAddVect.x;
        result.y += toAddVect.y;
        result.z += toAddVect.z;
        return result;
    }
    public Vect4 Substraction(Vect4 toSubVect)
    {
        Vect4 result = new Vect4(this.x, this.y, this.z);
        result.x -= toSubVect.x;
        result.y -= toSubVect.y;
        result.z -= toSubVect.z;
        return result;
    }
    public Vect4 Invert()
    {
        Vect4 result = new Vect4(this.x, this.y, this.z);
        result.x *= -1;
        result.y *= -1;
        result.z *= -1;
        return result;
    }
    public float DotProduct(Vect4 v1, Vect4 v2)
    {
        float result = 0;
        result = v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        return result;
    }
    public Vect4 CrossProduct(Vect4 v1, Vect4 v2)
    {
        float x = v1.y * v2.z - v2.y * v1.z;
        float y = (v1.x * v2.z - v2.x * v1.z) * -1;
        float z = v1.x * v2.y - v2.x * v1.y;
        return new Vect4(x, y, z);
    }
    public Vect4 Normalize()
    {
        float mag = Magnitude();
        Vect4 result = new Vect4(this.x/mag, this.y/mag, this.z/mag);
        return result;

    }
    public float Magnitude()
    {
        float result = 0;
        result = Mathf.Sqrt(x * x + y * y + z * z);
        return result;
    }
    public Vector3 Convert()
    {
        Vector3 result = new Vector3(this.x, this.y, this.z);
        return result;
    }


}
