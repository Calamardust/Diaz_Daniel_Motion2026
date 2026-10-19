using UnityEngine;

public class NeutronStar : MonoBehaviour
{
    public float rotationSpeed; // Speed at which the neutron star rotates

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime); // Rotates the neutron star around its Z-axis

    }
}
