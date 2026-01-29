using UnityEngine;
using UnityEngine.InputSystem;

public class LookerExercise : MonoBehaviour
{
    public Camera gameCamera;

    public float zMin;
    public float zMax;

    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ROTATING IN A DIRECTION AND SWAPPING

        //Vector3 lookerRotation = transform.eulerAngles;
        //lookerRotation.z += Time.deltaTime * speed;
        //transform.eulerAngles = lookerRotation;

        //Vector3 lookerScreenRotation = Camera.current.ScreenToWorldPoint(transform.eulerAngles);
        //zMax = 360f;
        //zMin = 0f;

        //if (lookerScreenRotation.z < zMin)
        //{
        //    speed *= -1;
        //}
        //if (lookerScreenRotation.z > zMax)
        //{
        //    speed *= -1;
        //}

        //Debug.Log(transform.eulerAngles);

        Vector3 currentMousePosition = Mouse.current.position.ReadValue();
        Vector3 worldMousePosition = gameCamera.ScreenToWorldPoint(currentMousePosition);
        worldMousePosition.z = 0;

        //Setting direction we're lookin in
        //To set this up, you have to do END - START
        transform.up = worldMousePosition - transform.position;

        transform.position += transform.up * 1f * Time.deltaTime;
    }
}
