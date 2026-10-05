using System;
using UnityEngine;

public class TestAngles : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //float firstAngle = 45f;
        //float secondAngle = 315f;

        //float firstVectorX = Mathf.Cos(firstAngle * Mathf.Deg2Rad);
        //float secondVectorX = Mathf.Cos(secondAngle * Mathf.Deg2Rad);

        //Debug.Log($"First Vector X: {firstVectorX}");
        //Debug.Log($"Second Vector X: {secondVectorX}");

        //float firstVectorX2 = Mathf.Acos(firstVectorX) * Mathf.Rad2Deg;
        //float secondVectorX2 = Mathf.Acos(secondVectorX) * Mathf.Rad2Deg;

        //Debug.Log($"First Vector X (Inverse): {firstVectorX2}");
        //Debug.Log($"Second Vector X (Inverse): {secondVectorX2}");

        // both gave us 45 degrees

        //float x = 0.7f;
        //float y = -0.7f;

        //float angle = Mathf.Atan(y / x); // 0 value

        //float x2 = -0.7f;
        //float y2 = 0.7f;

        //float angle2 = Mathf.Atan(y2 / x2); // 0 value

        //MathF.Atan2(0.7f, -0.7f); // 2.3561945 value
        //Debug.Log($"Angle: {MathF.Atan2(0.7f, -0.7f) * Mathf.Rad2Deg}");
        //Debug.Log($"Angle: {MathF.Atan2(0.7f, -0.7f)}");// works as expected, gives us 135 degrees
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static float VectortoAngle(Vector2 vector) // Convert a Vector2 to an angle in degrees
    {
        float angle =Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;

        return angle-90f;
    }

    public static float VectorDot(Vector3 a, Vector3 b)
    {
       float dotProduct = a.x * b.x + a.y * b.y;
        return dotProduct;
    }
}
