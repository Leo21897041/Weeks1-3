using UnityEngine;
using UnityEngine.InputSystem;

public class HideBird : MonoBehaviour
{
    //variables for position and lowest height it can spawn
    public Vector3 newPosition;
    public float minHideHeight = -3.5f;
    //debug
    public bool isWorking = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Variable for the current position of the mouse on the screen space
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        //Variable for converting the value position of the mouse from the screen space to finding the position of the mouse in the world space
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //Sets the z position of the mouse to 0. Stays in line with all the other game assets
        mouseWorldPosition.z = 0f;

        //finds the distance from the mouse to the bird
        float mouseToObject = Vector3.Distance(mouseWorldPosition, transform.position);

        //runs this if the mouse is less than one unit from the object
        if (mouseToObject < 1)
        {
            //Variable for setting the position of the bird to the new position
            Vector3 screenPosition = newPosition;
            //Move the bird to a random position on the x axis
            screenPosition.x = Random.Range(0, Screen.width);
            //Always move the bird to this height on the y axis
            screenPosition.y = minHideHeight;

            //Set the newPosition Vector3 variable to the random x and consistent y values
            newPosition = screenPosition;
            //Convert the position of the birds in the world space to the position of the birds in the screen space
            newPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            newPosition.z = 0;
            //Sets this conversion to the values in the inspector
            transform.position = newPosition;

            //This is just a debug to see if this if statement was working
            isWorking = true;
        }
        else 
        {
            //This is just a debug to see if this if statement was working
            isWorking = false;
        }
    }
}
