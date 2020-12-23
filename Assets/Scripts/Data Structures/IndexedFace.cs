using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class IndexedFace
{

    private int[] indices;
    public Vect4[] localPoints = new Vect4[3];
    
    //used for animation and visualisation of faces
    //final meaning after multiplying with projection matrix
    private Vect4[] finalPoints = new Vect4[3];
    private LineRenderer lr;
    public IndexedFace(LineRenderer lr, Vect4 p1, Vect4 p2, Vect4 p3, int[] indices)
    {

        this.lr = lr;
        this.localPoints[0] = p1;
        this.localPoints[1] = p2;
        this.localPoints[2] = p3;
    }
    //Display the face on screen
    public void UpdateLines()
    {
        lr.SetPosition(0, new Vector3(finalPoints[0].x, finalPoints[0].y, 0));
        lr.SetPosition(1, new Vector3(finalPoints[1].x, finalPoints[1].y, 0));
        lr.SetPosition(2, new Vector3(finalPoints[2].x, finalPoints[2].y, 0));
        lr.SetPosition(3, new Vector3(finalPoints[0].x, finalPoints[0].y, 0));
    }
    //Display the face, by slowly animating from last transformation
    public void TweenLines()
    {
        DOTween.To(() => lr.GetPosition(0), (x) => lr.SetPosition(0, x), new Vector3(finalPoints[0].x, finalPoints[0].y, 0), 2).Play();
        DOTween.To(() => lr.GetPosition(3), (x) => lr.SetPosition(3, x), new Vector3(finalPoints[0].x, finalPoints[0].y, 0), 2).Play();
        DOTween.To(() => lr.GetPosition(1), (x) => lr.SetPosition(1, x), new Vector3(finalPoints[1].x, finalPoints[1].y, 0), 2).Play();
        DOTween.To(() => lr.GetPosition(2), (x) => lr.SetPosition(2, x), new Vector3(finalPoints[2].x, finalPoints[2].y, 0), 2).Play();
    }
    //Update point for view
    public void UpdateFinalPoint(int index, Vect4 point)
    {
        finalPoints[index] = point;
    }
    //Update local point
    public void UpdateLocalPoint(int index, Vect4 point)
    {
        localPoints[index] = point;
    }
    public Vect4[] GetCurrentPoints()
    {
        return localPoints;
    }
}
