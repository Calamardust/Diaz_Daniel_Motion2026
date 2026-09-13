using TMPro;
using UnityEngine;



public class RowGeneration : MonoBehaviour
{
    int squareN;
    public TMP_InputField inputField; // Reference to the TMP_InputField component

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    public void Generate()// Generate the squares 
    {
        Readtext();// Reads the number writen into the field

        for (int i = 0; i < squareN; i++)// Creates an I value that increases until it mactches the munber put on the field
        {
            // Coordinates for the 4 corners of the square
            // I value moves the x cordinates to create a continous row of squares
            Vector2 topL = new Vector2(-1 +i*2, 1);
            Vector2 topR = new Vector2(1 +i*2, 1);
            Vector2 bottomL = new Vector2(-1 +i*2, -1);
            Vector2 bottomR = new Vector2(1 +i*2, -1);

            //Draws the lines to form the square
            Debug.DrawLine(topL, topR, Color.red, 15);
            Debug.DrawLine(topR, bottomR, Color.red, 15);
            Debug.DrawLine(bottomR, bottomL, Color.red, 15);
            Debug.DrawLine(bottomL, topL, Color.red, 15);

        }
    }
    void Readtext()// Reads the number writen into the field and converts it into an integer
    {
        string rowNumberString = inputField.text; // Gets the text from the input field

        squareN = int.Parse(rowNumberString);// Converts into an integer

    }
}
