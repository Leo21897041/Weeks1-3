using UnityEngine;

public class BirdUpAndDown : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public float progress = 0;
    public Vector3 output;

    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        progress += Time.deltaTime / speed;
        output = Vector3.Lerp(A.position, B.position, progress);
        Vector3 newPosition = transform.position;
        newPosition.y = output.y;
        transform.position = newPosition;

        if (progress > 1 || progress < 0)
        {
            speed *= -1;
        }
    }
}
