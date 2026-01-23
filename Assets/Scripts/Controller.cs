using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Controller : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;

    public SpriteRenderer spriteRenderer;
    public Color startingColor;

    public List<SpriteRenderer> controllableRenderers;
    public List<Transform> controlledTransforms;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer.color = startingColor;
        bool isInsideSprite = spriteRenderer.bounds.Contains(transform.position);

        controlledTransforms.Add(transform);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentMousePosition = Mouse.current.position.ReadValue();
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(currentMousePosition);
        worldMousePosition.z = 0;

        bool isLeftMousePressed = Mouse.current.leftButton.wasPressedThisFrame;
        if (isLeftMousePressed)
        {
            //find any renders that are currently hovered over

            //Iterate over all the sprites and determine if any are hovered over
            for (int i = 0; i < controllableRenderers.Count; i++)
            {
                SpriteRenderer currentSpriteRenderer = controllableRenderers[i];
                bool isHovered = currentSpriteRenderer.bounds.Contains(worldMousePosition);
                if (isHovered)
                {
                    controlledTransforms.Add(currentSpriteRenderer.transform);
                }
            }
        }

        for (int i = 0; i < controlledTransforms.Count; i++)
        {
            Transform currentTransform = controlledTransforms[i];

            bool wIsHeld = Keyboard.current.wKey.isPressed;
            bool aIsHeld = Keyboard.current.aKey.isPressed;
            bool sIsHeld = Keyboard.current.sKey.isPressed;
            bool dIsHeld = Keyboard.current.dKey.isPressed;

            if (aIsHeld)
            {
                currentTransform.eulerAngles -= currentTransform.forward * rotateSpeed * Time.deltaTime;
            }

            if (dIsHeld)
            {
                currentTransform.eulerAngles += currentTransform.forward * rotateSpeed * Time.deltaTime;
            }

            if (wIsHeld)
            {
                currentTransform.position += currentTransform.up * rotateSpeed * Time.deltaTime;
            }

            if (sIsHeld)
            {
                currentTransform.position -= currentTransform.up * rotateSpeed * Time.deltaTime;
            }
        }

        //leftButton and rightButton do the same thing
        //bool leftIsHeld = Mouse.current.leftButton.isPressed;

        //if (leftIsHeld)
        //{
        //    Debug.Log("Left mouse is held");
        //}

        //bool leftIsPressed = Mouse.current.leftButton.wasPressedThisFrame;
        //if (leftIsPressed)
        //{
        //    Debug.Log("Left mouse is pressed");
        //}

        //bool leftIsReleased = Mouse.current.leftButton.wasReleasedThisFrame;
        //if (leftIsReleased)
        //{
        //    Debug.Log("Left mouse is released");
        //}

        ////MINE
        //Vector3 currentPosition = transform.position;
        //Vector3 currentRotation = transform.eulerAngles;

        //bool wIsPressed = Keyboard.current.wKey.isPressed;
        //bool aIsPressed = Keyboard.current.aKey.isPressed;
        //bool sIsPressed = Keyboard.current.sKey.isPressed;
        //bool dIsPressed = Keyboard.current.dKey.isPressed;

        //if (wIsPressed)
        //{
        //    currentRotation.x += Time.deltaTime * rotateSpeed;
        //    transform.eulerAngles = currentRotation;

        //    currentPosition.y += Time.deltaTime * moveSpeed;
        //    transform.position = currentPosition;

        //    Debug.Log("w is pressed");
        //}
        //if (aIsPressed)
        //{
        //    currentRotation.z += Time.deltaTime * rotateSpeed;
        //    transform.eulerAngles = currentRotation;

        //    currentPosition.x -= Time.deltaTime * moveSpeed;
        //    transform.position = currentPosition;

        //    Debug.Log("a is pressed");
        //}
        //if (sIsPressed)
        //{
        //    currentRotation.x -= Time.deltaTime * rotateSpeed;
        //    transform.eulerAngles = currentRotation;

        //    currentPosition.y -= Time.deltaTime * moveSpeed;
        //    transform.position = currentPosition;

        //    Debug.Log("s is pressed");
        //}
        //if (dIsPressed)
        //{
        //    currentRotation.z -= Time.deltaTime * rotateSpeed;
        //    transform.eulerAngles = currentRotation;

        //    currentPosition.x += Time.deltaTime * moveSpeed;
        //    transform.position = currentPosition;

        //    Debug.Log("d is pressed");
        //}
    }
}



        