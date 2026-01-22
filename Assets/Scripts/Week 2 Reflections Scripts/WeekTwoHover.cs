using UnityEngine;
using UnityEngine.InputSystem;

public class WeekTwoHover : MonoBehaviour
{
    public bool isHovering = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 distanceToMouse = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        float objectDistance = Vector2.Distance(transform.position, distanceToMouse);

        if (objectDistance < 1)
        {
            isHovering = true;
        }
        else
        {
            isHovering = false;
        }
    }
}
