using UnityEngine;
using UnityEngine.InputSystem;

public class HideBird : MonoBehaviour
{
    public Vector3 hidePosition;
    public bool isWorking = false;
    public float minHideHeight = -3.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mouseWorldPosition.z = 0f;
        float mouseToObject = Vector3.Distance(mouseWorldPosition, transform.position);

        if (mouseToObject < 1)
        {
            Vector3 screenPosition = hidePosition;
            screenPosition.x = Random.Range(0, Screen.width);
            screenPosition.y = minHideHeight;
            hidePosition = screenPosition;
            hidePosition = Camera.main.ScreenToWorldPoint(screenPosition);
            hidePosition.z = 0;
            isWorking = true;
            transform.position = hidePosition;
        }
        else 
        {
            isWorking = false;
        }
    }
}
