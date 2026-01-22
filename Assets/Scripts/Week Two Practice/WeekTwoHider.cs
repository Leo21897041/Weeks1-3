using UnityEngine;
using UnityEngine.InputSystem;

public class WeekTwoHider : MonoBehaviour
{
    public Vector3 hiderPosition;
    public Camera gameCamera;
    public float objectDistance;

    //debug
    public bool isWorking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector2 currentMousePosition = Mouse.current.position.ReadValue();
        Vector2 globalMousePosition = gameCamera.ScreenToWorldPoint(currentMousePosition);
        float mouseDistance = Vector3.Distance(currentPosition, globalMousePosition);
    
            if (mouseDistance < objectDistance)
        {
            transform.position = hiderPosition;
            //debug
            isWorking = true;
        }
    }
}