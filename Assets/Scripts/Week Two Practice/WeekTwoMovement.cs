using UnityEngine;

public class WeekTwoMovement : MonoBehaviour
{
    public float xSpeed = 1f;
    public float ySpeed = 1f;

    public Camera gameCamera;
    public float xMax;
    public float yMax;

    public float xMin;
    public float yMin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x += Time.deltaTime * xSpeed;
        position.y += Time.deltaTime * ySpeed;
        position.z = 0f;

        transform.position = position;

        Vector3 screenPosition = gameCamera.WorldToScreenPoint(transform.position);
        xMax = Screen.width;
        xMin = 0;
        yMax = Screen.height;
        yMin = 0;

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
