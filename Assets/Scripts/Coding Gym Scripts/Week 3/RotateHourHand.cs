using UnityEngine;

public class RotateHourHand : MonoBehaviour
{
    public float rotateSpeed;
    public Transform centerPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 centerPointRotation = transform.eulerAngles;
        centerPointRotation.z += Time.deltaTime * rotateSpeed;
        transform.eulerAngles = centerPointRotation;
    }
}
