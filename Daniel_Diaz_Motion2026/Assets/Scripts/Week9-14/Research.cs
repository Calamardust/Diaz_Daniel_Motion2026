using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Research : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;

    public Collider2D Collider2D;

    public Vector2 checkPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setAngularVelocity(100f);// Angular velocity works as a one time value in start

        
    }

    // Update is called once per frame
    void Update()
    {
        closestPointTo(checkPoint, Collider2D);
        Debug.Log("Closest Point: " + Collider2D.ClosestPoint(checkPoint));

        if (Keyboard.current.spaceKey.isPressed) // breaks the rotation over time when space is pressed, otherwise it will keep rotating
        {
            setAngularDamping(0.5f);
        }
        else
        {
            setAngularDamping(0f);
        }

        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            setAngularVelocity(200f);// Angular velocity works as a constant value in update
        }
       


        RaycastHit2D hit = BoxCast(transform.position + transform.up * 1f, new Vector2(1, 1), 0, Vector2.up, 5f, LayerMask.GetMask("Default"), -Mathf.Infinity, Mathf.Infinity);
    }

    public  RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth) //Boxcast Test / detectes colliders in a box shape along a direction and distance, returns the first collider hit, 
    {
        RaycastHit2D hit = Physics2D.BoxCast(origin, size, angle, direction, distance, layerMask, minDepth, maxDepth);

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
        }

        return hit;
        // I need to find a way to make the box visible
    }

    public void setAngularVelocity(float value)// Angular Velocity Test / Rotation speed of objects in degrees per second.
    {
        Rigidbody2D.angularVelocity = value;
    }
    public void setAngularDamping(float value)// Angular Damping Test / Breaks the rotation oever time
    {
        Rigidbody2D.angularDamping = value;
    }
    
    public static Vector2 closestPointTo(Vector2 position, Collider2D collider) // Closest Point Test / Returns the closest point on the collider to the specified position.
    {
        return collider.ClosestPoint(position);
    }
       
    

}
