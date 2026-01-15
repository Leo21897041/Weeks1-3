using UnityEngine;

public class FirstScript : MonoBehaviour
{
    public float speed = 0.01f;

    Vector2 bottomLeft;
    Vector2 topRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(Vector2.zero);
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        //speed = Random.Range(0.01f, 0.3f);
        transform.position = (Vector2)transform.position + Random.insideUnitCircle * 2;
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the square
        Vector3 newPosition = transform.position;
        newPosition.x += speed * Time.deltaTime;

        //Checks if square reaches the ends of the screen
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        //Left edge
        if (screenPos.x < 0)
        {
            newPosition.x = bottomLeft.x;

            speed *= -1;
        }

        //Right edge
        if (screenPos.x > Screen.width)
        {
            newPosition.x = topRight.x;

            speed *= -1;
        }

        transform.position = newPosition;
    }
}
