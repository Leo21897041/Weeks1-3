using UnityEngine;

public class FirstScript : MonoBehaviour
{
    public float speed = 0.01f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //speed = Random.Range(0.01f, 0.3f);
        transform.position = (Vector2)transform.position + Random.insideUnitCircle * 2;
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the square
        Vector3 newPosition = transform.position;
        newPosition.x += speed;
        transform.position = newPosition;

        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x < 0 || screenPos.x > Screen.width)
        {
            speed *= -1;
        }
    }
}
