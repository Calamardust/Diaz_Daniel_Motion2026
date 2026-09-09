using UnityEngine;
using UnityEngine.InputSystem;

public class SquareSpawner : MonoBehaviour
{
    
    //float scroll = Mouse.current.scroll.ReadValue().y;
    //Debug.Log(scroll);
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SquareFollow();
       
    }

    void SquareFollow() // Fuction to draw a square tha follows the mouse
    {

        // Read mouse cordinates and translate
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        transform.position = mousePos;
        int size = 1;

        // Coordinates for the 4 corners of the square
        Vector2 topL = new Vector2(mousePos.x - size, mousePos.y + size);
        Vector2 topR = new Vector2(mousePos.x + size, mousePos.y + size);
        Vector2 bottomL = new Vector2(mousePos.x - size, mousePos.y - size);
        Vector2 bottomR = new Vector2(mousePos.x + size, mousePos.y - size);

        //Draws the lines to form the square
        Debug.DrawLine(topL, topR, Color.grey);
        Debug.DrawLine(topR, bottomR, Color.grey);
        Debug.DrawLine(bottomR, bottomL, Color.grey);
        Debug.DrawLine(bottomL, topL, Color.grey);

    }
  
    public void OnClick(InputAction.CallbackContext context) // Function to draw news squares on click
    {
        
        // Only on Inmediate Click
         if (context.started)
        {
            // Read mouse cordinates and translate
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            transform.position = mousePos;
            int size = 1;

            // Coordinates for the 4 corners of the square
            Vector2 topL = new Vector2(mousePos.x - size, mousePos.y + size);
            Vector2 topR = new Vector2(mousePos.x + size, mousePos.y + size);
            Vector2 bottomL = new Vector2(mousePos.x - size, mousePos.y - size);
            Vector2 bottomR = new Vector2(mousePos.x + size, mousePos.y - size);

            //Draws the lines to form the square
            Debug.DrawLine(topL, topR, Color.white, 15);
            Debug.DrawLine(topR, bottomR, Color.white, 15);
            Debug.DrawLine(bottomR, bottomL, Color.white, 15);
            Debug.DrawLine(bottomL, topL, Color.white, 15);
            
        }

    }
    public void OnScroll(InputAction.CallbackContext context)
    {

    }
}
