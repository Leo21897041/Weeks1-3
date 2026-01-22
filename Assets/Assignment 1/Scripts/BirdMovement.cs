using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    //speed variables made public to adjust in the inspector
    public float xSpeed = 1f;
    public float ySpeed = 1f;

    //Opens up the sdata in the inspector
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    //camera variable to create border for game object
    public Camera gameCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //creates a variable that is declairs the initial position of the game object
        Vector3 position = transform.position;

        //Adds to the position every frame and the * variables allow me to adjust the speed in the inspector
        position.x += Time.deltaTime * xSpeed;
        position.y += Time.deltaTime * ySpeed;
        position.z = 0f;

        //Moves the game object this script is attached to
        transform.position = position;

        //Creating the bouncing effect
        Vector3 screenPosition = gameCamera.WorldToScreenPoint(transform.position);
        
        //The walls preventing the game object from leaving
        float xMin = 0f;
        float xMax = Screen.width;
        float yMin = 0f;
        float yMax = Screen.height;

        //conditionals to check if the game object has reached a condition every frame
        if (screenPosition.x < xMin)
        {
            xSpeed *= -1f;
        }
        if (screenPosition.x > xMax)
        {
            xSpeed *= -1f;
        }
        if (screenPosition.y < yMin)
        {
            ySpeed *= -1f;
        }
        if (screenPosition.y > yMax)
        {
            ySpeed *= -1f;
        }
    }
}
