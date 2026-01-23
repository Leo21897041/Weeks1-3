using UnityEngine;

public class Looker : MonoBehaviour
{
    public float rotationSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position moves object
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.z += Time.deltaTime * rotationSpeed;
        transform.eulerAngles = currentRotation;

        Debug.Log(rotationSpeed);
    }
}
