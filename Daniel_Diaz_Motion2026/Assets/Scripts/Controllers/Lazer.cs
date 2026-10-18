using UnityEngine;
using UnityEngine.InputSystem;

public class Lazer : MonoBehaviour
{
    public GameObject laserPrefab;
    Vector3 mouseAim;
    Vector3 directionOfFire;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            FireLaser();
        }
    }

    void Aim ()
    {
        // assign to the fields instead of declaring new local variables
        mouseAim = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouseAim.z = 0f; 
        directionOfFire = (mouseAim - transform.position).normalized;
        Debug.DrawRay(transform.position, directionOfFire * 2f, Color.red);
    }

    void FireLaser()
    {
        Instantiate(laserPrefab, transform.position, transform.rotation);
    }
}
