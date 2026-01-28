using UnityEngine;
using UnityEngine.InputSystem;

public class Crosshair : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //finds the mouse position on the screen and convert it to the game objects position in the world space
        Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //sets the position of the game object in the world space to the position of the mouse in the screen space
        transform.position = currentMousePosition;
    }
}
