using Unity.VisualScripting;
using UnityEngine;

public class DogUpAndDown : MonoBehaviour
{
    //Variables for movement
    public Vector3 dogPosition;
    public float speed = 1f;
    public float maxHeight = -0.5f;
    public float minHeight = -4f;

    //Variables for the timer
    public float timer = 0f;
    public float timeSpeed = 1f;
    public float maxTimer = 4f;
    public float minTimer = 0f;

    //Switches for going up and down
    public bool isGoingUp = false;
    public bool isGoingDown = false;
    public bool isAtBottom = false;


    public Transform startingPoint;
    public Transform endingPoint;
    public float progressMeter = 0;
    public float movementSpeed;
    public Vector3 output;

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    //Starts the game with the dog moving up
        isGoingUp = true;
        isGoingDown = false;
    }

    // Update is called once per frame
    void Update()
    {
    //Adds movement and a timer to the boolean to move the dog up
        if (isGoingUp == true)
        {
            //moves the dog up if the dog is less than the max height it can go
            if (dogPosition.y <= maxHeight)
            {
                progressMeter += Time.deltaTime / movementSpeed;
                output = Vector3.Lerp(startingPoint.position, endingPoint.position, progressMeter);
                output.z = 0f;
                dogPosition.y += output.y;
            }
            //starts a timer for when the dog does reach the top
            if (dogPosition.y > maxHeight)
            {
                timer += Time.deltaTime * timeSpeed;
            }
        }
    //When the timer exceeds the maximumTimer value, switch directions of the dog
        if (timer > maxTimer)
        {
            isGoingUp = false;
            isGoingDown = true;
        }

    //Adds movement and a timer to the boolean to move the dog down
        if (isGoingDown == true)
        {
            //Move the dog down if the dog's y position is greater than the minimumHeight value
            if (dogPosition.y >= minHeight)
            {
                progressMeter -= Time.deltaTime / movementSpeed;
                output = Vector3.Lerp(startingPoint.position, endingPoint.position, progressMeter);
                output.z = 0f;
                dogPosition.y -= output.y;
            }
            //When the dog's position passes the minnimum height, start the timer 
            if (dogPosition.y < minHeight)
            {
                timer -= Time.deltaTime * timeSpeed;
            }
        }
    //Moves the dogs position to a random position on the x axis before moving back up
        if (timer < minTimer)
        {
            //sets the timer to back to the same value
            timer = minTimer;
            //Creates a Vector3 variable for the dogs position
            Vector3 screenPosition = dogPosition;
            //Moves the dog to a random position on the x axis
            screenPosition.x = Random.Range(0, Screen.width);

            //Takes the variables screen position value, then converts and sets it to the world position
            dogPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            dogPosition.y = minHeight;
            dogPosition.z = 0;

    //Move the dog up
            isGoingUp = true;
            isGoingDown = false;
        }

    //Sets this conversion to the values in the inspector
        transform.position = dogPosition;
    }
}
