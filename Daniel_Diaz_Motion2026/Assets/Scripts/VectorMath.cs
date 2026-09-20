using UnityEngine;
using UnityEngine.InputSystem;

public class VectorMath : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //DrawSquare(currentMousePosition, 5f, Color.red, 0.5f);
    }

    public static Vector2 GetNormalizedVector(Vector2 vector)
    {
        float sizeOfVector = GetMagnitude(vector);
        Vector2 normalizedVector = new Vector2(vector.x / sizeOfVector, vector.y / sizeOfVector);
        return normalizedVector;
    }

    public static float GetMagnitude(Vector2 vector)
    {
        // Calculate the magnitude of a 2D vector using the Pythagorean theorem
        // mathf.sqrt means square root
        return Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y);
    }

    // static method makes it accessible without creating an instance of the class
    public static void DrawSquare(Vector2 centerPoint, float size, Color color, float lifetime)
    {
        // Four corners of the square
        // Come back to fix 

        //Top line
        Vector2 startPoint = centerPoint + new Vector2(-size, size);
        Vector2 endPoint = centerPoint + new Vector2(size, size);

        Debug.DrawLine(startPoint, endPoint, color, lifetime);

        //Left line
        startPoint = centerPoint + new Vector2(-size, size);
        endPoint = centerPoint + new Vector2(-size, -size);

        Debug.DrawLine(startPoint, endPoint, color, lifetime);

        //Bottom line
        startPoint = centerPoint + new Vector2(-size, -size);
        endPoint = centerPoint + new Vector2(size, -size);

        Debug.DrawLine(startPoint, endPoint, color, lifetime);

        //Right line
        startPoint = centerPoint + new Vector2(size, size);
        endPoint = centerPoint + new Vector2(size, -size);

        Debug.DrawLine(startPoint, endPoint, color, lifetime);
    }
}
