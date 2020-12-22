using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MatType
{
    empty,
    identity,
    translation,
    scale,
    rotx,
    roty,
    rotz,
}

public class Mat4
{
    public float[,] members=new float[4,4];
    public Mat4(MatType type)
    {
        InitializeArray();
        switch (type)
        {
            case MatType.identity:
                {
                    members = new float[4, 4];
                    members[0,0] = 1;
                    members[1, 1] = 1;
                    members[2, 2] = 1;
                    members[3, 3] = 1;
                    break;
                }
        }
    }
    public Mat4(MatType type, Vect4 change)
    {
        InitializeArray();
        switch (type)
        {
            case MatType.scale:
                {
                    members[0, 0] = change.x;
                    members[1, 1] = change.y;
                    members[2, 2] = change.z;
                    members[3, 3] = 1;
                    break;
                }
            case MatType.translation:
                {
                    members[3, 0] = change.x;
                    members[3, 1] = change.y;
                    members[3, 2] = change.z;
                    members[0, 0] = 1;
                    members[1, 1] = 1;
                    members[2, 2] = 1;
                    members[3, 3] = 1;
                    break;
                }
        }
    }
    public Mat4(MatType type, float angle)
    {
        InitializeArray();
        angle = Mathf.Deg2Rad*angle;
        switch (type)
        {
            case MatType.rotx:
                {
                    members[0, 0] = 1;
                    members[1, 1] = Mathf.Cos(angle);
                    members[2, 1] = -Mathf.Sin(angle);
                    members[1, 2] = Mathf.Sin(angle);
                    members[2, 2] = Mathf.Cos(angle);
                    members[3, 3] = 1;
                    break;
                }
            case MatType.roty:
                {
                    members[1, 1] = 1;
                    members[0, 0] = Mathf.Cos(angle);
                    members[2, 0] = Mathf.Sin(angle);
                    members[0, 2] = -Mathf.Sin(angle);
                    members[2, 2] = Mathf.Cos(angle);
                    members[3, 3] = 1;
                    break;
                }
            case MatType.rotz:
                {
                    members[2, 2] = 1;
                    members[0, 0] = Mathf.Cos(angle);
                    members[1, 0] = -Mathf.Sin(angle);
                    members[0, 1] = Mathf.Sin(angle);
                    members[1, 1] = Mathf.Cos(angle);
                    members[3, 3] = 1;
                    break;
                }
        }
    }
    public Mat4 Multiply(Mat4 other)
    {
        Mat4 result = new Mat4(MatType.empty);
        for (int i = 0; i < 4; i++)
        {
            for (int d = 0; d < 4; d++)
            {
                result.members[i, d] = 0;
                for (int k = 0; k < 4; k++)
                {
                    result.members[i, d] += this.members[i, k] * other.members[k, d];
                }
            }
        }
        /*for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Debug.Log(result.members[i, j]);
            }
        }*/
        return result;
    }
    public Vect4 Multiply(Vect4 other)
    {
        Vect4 result = new Vect4(0, 0, 0);
        float[] tempResult = new float[] { 0, 0, 0, 0 };
        float[] tempOther = new float[] { other.x, other.y, other.z, other.w };
        for (int i = 0; i < 4; i++)
        {
            for(int d = 0; d < 4; d++)
            {
                tempResult[i] += (this.members[d,i] * tempOther[d]);
            }

        }
        result.x = tempResult[0];
        result.y = tempResult[1];
        result.z = tempResult[2];
        result.w = tempResult[3];
        //Debug.Log(result.x + " " + result.y + " " + result.z + " " + result.w);
        return result;
    }
    public void InitializeArray()
    {
        members = new float[4, 4];
        for(int i = 0; i < 4; i++)
        {
            for(int d = 0; d < 4; d++)
            {
                members[i, d] = 0;
            }
        }
    }
}
