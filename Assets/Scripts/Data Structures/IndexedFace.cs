using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class IndexedFace
{
    private LineRenderer lr;
    private int index;
    private Vect4[] points = new Vect4[3];
    public IndexedFace(int index, LineRenderer lr, Vect4 p1, Vect4 p2, Vect4 p3)
    {
        this.index = index;
        this.lr = lr;
        this.points[0] = p1;
        this.points[1] = p2;
        this.points[2] = p3;
    }
    public void UpdateLine()
    {
        lr.SetPosition(0, new Vector3(points[0].x, points[0].y, 0));
        lr.SetPosition(1, new Vector3(points[1].x, points[1].y, 0));
        lr.SetPosition(2, new Vector3(points[2].x, points[2].y, 0));
        lr.SetPosition(3, new Vector3(points[0].x, points[0].y, 0));
    }
    public void UpdatePoint(int index, Vect4 point)
    {
        points[index] = point;
    }
    public Vect4[] GetPoints()
    {
        return points;
    }
}
