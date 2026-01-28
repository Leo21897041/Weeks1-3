using Unity.VisualScripting;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    //public variable to see the position of my game object
    public Vector3 position;
    public Vector3 startPosition;

    //speed variables made public to adjust in the inspector
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

    //camera variable to create border for game object
    public Camera gameCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 screenPosition = startPosition;
        screenPosition.x = Random.Range(0, Screen.width);
        screenPosition.y = ySpawnMin;
        startPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        startPosition.z = 0f;
        transform.position = startPosition;

        isTop = true;
        isLeft = true;
        isRight = false;
        isBottom = false;
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        //Creating the bouncing effect
        Vector3 screenPosition = gameCamera.WorldToScreenPoint(transform.position);
        
        //The walls preventing the game object from leaving
        float xMin = 0f;
        float xMax = Screen.width;
        float yMin = 0f;
        float yMax = Screen.height;

        //conditionals to check if the game object has reached a condition every frame
        if (screenPosition.x <= xMin)
        {
            isLeft = true;
            isRight = false;
        }
        if (screenPosition.x >= xMax)
        {
            isLeft = false;
            isRight = true;
        }
        if (screenPosition.y <= yMin)
        {
            isBottom = true;
            isTop = false;
        }
        if (screenPosition.y >= yMax)
        {
            isBottom = false;
            isTop = true;
        }

        if (isLeft == true)
        {
            position.x += Time.deltaTime * xSpeed;
            position.z = 0f;
        }
        if (isRight == true)
        {
            position.x -= Time.deltaTime * xSpeed;
            position.z = 0f;
        }
        if (isTop == true)
        {
            position.y -= Time.deltaTime * ySpeed;
            position.z = 0f;
        }
        if (isBottom == true)
        {
            position.y += Time.deltaTime * ySpeed;
            position.z = 0f;
        }

        transform.position = position;
    }
}
