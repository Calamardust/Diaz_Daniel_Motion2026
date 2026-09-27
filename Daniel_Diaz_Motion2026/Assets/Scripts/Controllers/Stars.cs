using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle;
using Unity.VisualScripting;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime; // Time it takes for the moveT to reach the max

    public float T; // Timer value
    public float moveT; // Timer value for Lerp

    // Update is called once per frame
    void Update()
    {
        DrawConstellation();
    }
    public void DrawConstellation()
    {
        // Timers
        T += Time.deltaTime;
        moveT += Time.deltaTime;

        if (moveT >= drawingTime) { moveT = 0; } // Resets the timer every 0.5 seconds (every time a new line is made)

        // Individual star positions
        Vector3 starPoint = starTransforms[0].position;
        Vector3 secondPoint = starTransforms[1].position;
        Vector3 thirdPoint = starTransforms[2].position;
        Vector3 fourthPoint = starTransforms[3].position;
        Vector3 fifthPoint = starTransforms[4].position;
        Vector3 sixthPoint = starTransforms[5].position;
        Vector3 finalPoint = starTransforms[6].position;

        // Logic for drawing a line over time to the next star every 0.5 seconds
        if (T >= 0 && T <= 0.5)
        {
            Vector3 Move1 = starPoint;
            Move1 = Vector3.Lerp(Move1, secondPoint, moveT * 2);
            Debug.DrawLine(starPoint, Move1, Color.white);
            
        }
        if (T >= 0.5 && T <= 1)
        {
            Vector3 Move2 = secondPoint;
            Move2 = Vector3.Lerp(Move2, thirdPoint, moveT * 2);
            Debug.DrawLine(secondPoint, Move2, Color.white);
            
        }
        if (T >= 1 && T <= 1.5)
        {
            Vector3 Move3 = thirdPoint;
            Move3 = Vector3.Lerp(Move3, fourthPoint, moveT * 2);
            Debug.DrawLine(thirdPoint, Move3, Color.white);
        }
        if (T >= 1.5 && T <= 2)
        {
            Vector3 Move4 = fourthPoint;
            Move4 = Vector3.Lerp(Move4, fifthPoint, moveT * 2);
            Debug.DrawLine(fourthPoint, Move4, Color.white);
        }
        if (T >= 2 && T <= 2.5)
        {
            Vector3 Move5 = fifthPoint;
            Move5 = Vector3.Lerp(Move5, sixthPoint, moveT * 2);
            Debug.DrawLine(fifthPoint, Move5, Color.white);
        }
        if (T >= 2.5 && T <= 3)
        {
            Vector3 Move6 = sixthPoint;
            Move6 = Vector3.Lerp(Move6, finalPoint, moveT * 2);
            Debug.DrawLine(sixthPoint, Move6, Color.white);
        }
        if (T >= 3 && T <= 3.5)
        {
            Vector3 Move7 = finalPoint;
            Move7 = Vector3.Lerp(Move7, fourthPoint, moveT * 2);
            Debug.DrawLine(finalPoint, Move7, Color.white);
        }
        if (T >= 3.5 && T <= 4)
        {
            Vector3 Move8 = fourthPoint;
            Move8 = Vector3.Lerp(Move8, thirdPoint, moveT * 2);
            Debug.DrawLine(fourthPoint, Move8, Color.white);
        }
        if (T >= 4 && T <= 4.5)
        {
            Vector3 Move9 = thirdPoint;
            Move9 = Vector3.Lerp(Move9, secondPoint, moveT * 2);
            Debug.DrawLine(thirdPoint, Move9, Color.white);
        }
        if (T >= 4.5 && T <= 5)
        {
            Vector3 Move10 = secondPoint;
            Move10 = Vector3.Lerp(Move10, starPoint, moveT * 2);
            Debug.DrawLine(secondPoint, Move10, Color.white);
        }
        if (T >= 5) // Loop to reset the timer and start the restart the drawing process

        {
            T = 0;
        }
    }
}
