using UnityEngine;
using UnityEngine.InputSystem;

public class ForcesTest : MonoBehaviour
{
    public float forceStrength;
    public Rigidbody2D rb;

    public enum ProjectileType
    {
        CannonBall,
        Fireball,
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 mousePosition = Mouse.current.position.ReadValue();
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            worldMousePosition.z = 0f; // Set z to 0 for 2D

            Vector3 directionToApplyForce = worldMousePosition - transform.position;

            rb.AddForce(directionToApplyForce.normalized * forceStrength, ForceMode2D.Impulse);

            

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision entere");
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {

        Debug.Log("Collision exited");
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Collision stay");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger entered");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Trigger exited");
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Trigger stay");
    }
}
