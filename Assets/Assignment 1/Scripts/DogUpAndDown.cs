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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isGoingUp = true;
        isGoingDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGoingUp == true)
        {
            if (dogPosition.y < maxHeight)
            {
                dogPosition.y += Time.deltaTime * speed;
            }
            if (dogPosition.y > maxHeight)
            {
                timer += Time.deltaTime * timeSpeed;
            }
        }
        
        if (timer > maxTimer)
        {
            isGoingUp = false;
            isGoingDown = true;
        }

        if (isGoingDown == true)
        {
            if (dogPosition.y > minHeight)
            { 
                dogPosition.y -= Time.deltaTime * speed;
            }
            if (dogPosition.y < minHeight)
            {
                timer -= Time.deltaTime * timeSpeed;
            }
        }

        if (timer < minTimer)
        {
            timer = minTimer;
            Vector3 screenPosition = dogPosition;
            screenPosition.x = Random.Range(0, Screen.width);
            dogPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            dogPosition.y = minHeight;
            dogPosition.z = 0;

            //dogPosition = screenPosition;
            isGoingUp = true;
            isGoingDown = false;
        }

        transform.position = dogPosition;
    }
}
