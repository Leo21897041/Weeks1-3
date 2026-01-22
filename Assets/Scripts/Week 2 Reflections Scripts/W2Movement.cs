using UnityEngine;

public class MovingSquare : MonoBehaviour
{
    public float xSpeed = 1f;
    public float ySpeed = 1f;

    public Camera gameCamera;
    public float xMax;
    public float yMax;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 
        transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 xPos = transform.position;
        xPos.x += Time.deltaTime * xSpeed;
        xPos.y += Time.deltaTime * ySpeed;
        xPos.z = 0f;
        transform.position = xPos;

        Vector3 screenPosition = gameCamera.WorldToScreenPoint(transform.position);
        xMax = Screen.width;
        yMax = Screen.height;

        if (screenPosition.x < 0)
        {
            xSpeed *= -1f;
        }
        if (screenPosition.x >= Screen.width)
        {
            xSpeed *= -1f;
        }

        if (screenPosition.y < 0)
        {
            ySpeed *= -1f;
        }
        if (screenPosition.y > Screen.height)
        {
            ySpeed *= -1f;
        }


        //Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        //if (screenPos.x < 0)
        //{
        //    xSpeed *= -1f;
        //}
        //if (screenPos.x >= Screen.width)
        //{
        //    xSpeed *= -1f;
        //}

        //if (screenPos.y < 0)
        //{
        //    ySpeed *= -1f;
        //}
        //if (screenPos.y > Screen.height)
        //{
        //    ySpeed *= -1f;
        //}
    }
}
