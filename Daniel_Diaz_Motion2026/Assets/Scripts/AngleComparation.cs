using UnityEngine;
using UnityEngine.InputSystem;

public class AngleComparation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Vector3 facingDirection = transform.up;
            float facingAngle = TestAngles.VectortoAngle(facingDirection);

            Debug.Log("Facing Angle: " + facingAngle);
            Debug.Log("Euler Angle: " + transform.eulerAngles.z);
        }
    }
}
