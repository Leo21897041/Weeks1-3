using UnityEngine;
using UnityEngine.InputSystem;

public class CanMovement : MonoBehaviour
{
    public Vector3 position;
    public float speed;
    public float maxHeight;
    public float minHeight;

    public Vector3 mousePosition;
    public Vector3 mouseWorldPosition;

    public bool isUp = false;
    public bool isDown = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isUp = true;   
    }

    // Update is called once per frame
    void Update()
    {
        if (isUp == true)
        { 
            position.y += Time.deltaTime * speed;
        }

        if (isDown == true)
        {
            position.y -= Time.deltaTime * speed;
        }

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        minHeight = 0f;
        maxHeight = Screen.height - 50;

        if (screenPosition.y > maxHeight)
        {
            isUp = false;
            isDown = true;
        }
        if (screenPosition.y < minHeight)
        {
            isUp = true;
            isDown = false;
        }

            transform.position = position;

        mousePosition = Mouse.current.position.ReadValue();
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mouseWorldPosition.z = 0f;
        float distanceToMouse = Vector3.Distance(mouseWorldPosition, transform.position);

        if (distanceToMouse < 1)
        {
            isUp = true;
            isDown = false;
        }
    }
}
