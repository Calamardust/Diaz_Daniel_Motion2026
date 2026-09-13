using UnityEngine;
using UnityEngine.InputSystem;


public class Pipeline : MonoBehaviour
{
    public bool isHeld; // boolean to check if the mouse is held down

    float T;// Timer float
    Vector2 lastPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isHeld) //Only if the mouse is held down
        {
            // Read mouse cordinates and translate
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            transform.position = mousePos;

            Vector2 currentPos = new Vector2(mousePos.x, mousePos.y);// Vector2 for the current position of the mouse

            T += Time.deltaTime;//start timer   

            if (T >= 0.1f) // draws the line and updates the last position every 0.1 seconds
            {

                Debug.DrawLine(lastPos, currentPos, Color.green, 15);// Draws the line between the last position and the current position
                lastPos = new Vector2(mousePos.x, mousePos.y); // Updates the last position to the current position

                float length = lastPos.magnitude; // Gets the length of the line drawn betwen the last position and the current position
                Debug.Log("total length: " + length);

                T =0;// reset timer
            } 
        }
    }
    public void Drawing(InputAction.CallbackContext context) //Changes the boolean isHeld to true or false depending on the mouse state
    {
        if (context.performed)// if the mouse is held, isHeld = true
        {
            isHeld = true;
        }
        else if(context.canceled)// when and after the mouse is released, isHeld = false
        {
            isHeld = false;
            T= 0;// reset timer
        }
    }    
}

