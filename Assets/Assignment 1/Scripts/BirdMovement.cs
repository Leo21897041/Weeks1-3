using Unity.VisualScripting;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    //Public variable to see the position of my game object
    public Vector3 position;
    public Vector3 startPosition;

    //Speed variables made public to adjust in the inspector
    public float xSpeed = 1f;
    public float ySpeed = 1f;

    //Opens up the sdata in the inspector
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    public float ySpawnMin = -3.5f;

    public bool isLeft;
    public bool isRight;
    public bool isTop;
    public bool isBottom;

    //Camera variable to create border for game object
    public Camera gameCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Creates vector variable for the screen position of the duck the game starts
        Vector3 screenPosition = startPosition;
        //Sets the ducks position on the x axis to a random value
        screenPosition.x = Random.Range(0, Screen.width);
        //Sets the ducks starting position to a constant value
        screenPosition.y = ySpawnMin;
        //Converts the value of the screen position to the world position and sets it to this starting position variable 
        startPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        //Set the starting position of the ducks on the z axis to 0
        startPosition.z = 0f;
        //Set the value of the startPosition variable to the transform.position value
        transform.position = startPosition;

        //Starts the game with the ducks moving up and left
        isTop = true;
        isLeft = true;
        isRight = false;
        isBottom = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Sets the position of the ducks to the transform.position in the inspector
        position = transform.position;
        //Creating the bouncing effect
        //Create a Vector3 variable to convert the value of the ducks in the world space to the screen space value
        Vector3 screenPosition = gameCamera.WorldToScreenPoint(transform.position);

        //The walls preventing the game object from leaving
        float xMin = 0f;
        float xMax = Screen.width;
        float yMin = 0f;
        float yMax = Screen.height;

        //Conditionals to check if the game object has reached a condition every frame
        //If it hits the left side, go right
        if (screenPosition.x <= xMin)
        {
            isLeft = true;
            isRight = false;
        }
        //If it hits the right side, go left
        if (screenPosition.x >= xMax)
        {
            isLeft = false;
            isRight = true;
        }
        //If it hits the bottom, go up
        if (screenPosition.y <= yMin)
        {
            isBottom = true;
            isTop = false;
        }
        //If it hits the top, go down
        if (screenPosition.y >= yMax)
        {
            isBottom = false;
            isTop = true;
        }

        //If it hits the left side, move the object right and set the value of the position on the z axis to zero
        if (isLeft == true)
        {
            position.x += Time.deltaTime * xSpeed;
            position.z = 0f;
        }
        //If it hits the right side, move the object left and set the value of the position on the z axis to zero
        if (isRight == true)
        {
            position.x -= Time.deltaTime * xSpeed;
            position.z = 0f;
        }
        //If it hits the top, move the object down and set the value of the position on the z axis to zero
        if (isTop == true)
        {
            position.y -= Time.deltaTime * ySpeed;
            position.z = 0f;
        }
        //If it hits the bottom, move the object up and set the value of the position on the z axis to zero

        if (isBottom == true)
        {
            position.y += Time.deltaTime * ySpeed;
            position.z = 0f;
        }

        //Set the position in the inspector to the new position variable
        transform.position = position;
    }
}
