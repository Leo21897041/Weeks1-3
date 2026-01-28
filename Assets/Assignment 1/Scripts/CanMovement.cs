using UnityEngine;
using UnityEngine.InputSystem;

public class CanMovement : MonoBehaviour
{
    //Variables to store the position or speed of the can
    public Vector3 position;
    public float speed;
    public float maxHeight;
    public float minHeight;

    //Vector variables to store the position of the mouse on the screen, then convert it to the location in the world space
    public Vector3 mousePosition;
    public Vector3 mouseWorldPosition;

    //Booleans to switch the direction of the can
    public bool isUp = false;
    public bool isDown = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Start the program with the can moving up
        isUp = true;
        isDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        //adding movement to each boolean when it is active
        if (isUp == true)
        { 
            position.y += Time.deltaTime * speed;
        }
        if (isDown == true)
        {
            position.y -= Time.deltaTime * speed;
        }

        //Finds the position of the can in the world space and converts it to the position on the screen space
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        //Sets the min and max height the cans can go before switching directions  
        maxHeight = Screen.height - 50;
        minHeight = 0f;

        //Switches the booleans which switches the direction when the can reaches a certain position on the screen
        //Switches direction on the top
        if (screenPosition.y > maxHeight)
        {
            isUp = false;
            isDown = true;
        }

        //Switches direction on the bottom
        if (screenPosition.y < minHeight)
        {
            isUp = true;
            isDown = false;
        }

        //sets the position under the transform component to the position variable
        transform.position = position;

        //Finds the mouse position on the screen, then finds and converts the position on the screen to the location on the world space
        mousePosition = Mouse.current.position.ReadValue();
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //sets the mouse position on the z axis to 0 to make sure its aligned with all other objects
        mouseWorldPosition.z = 0f;

        //finds the distance between the mouse and the can
        float distanceToMouse = Vector3.Distance(mouseWorldPosition, transform.position);

        //switches the direction upwards but only if the can only if it is moving downwards
        if (distanceToMouse < 1)
        {
            isUp = true;
            isDown = false;
        }
    }
}
