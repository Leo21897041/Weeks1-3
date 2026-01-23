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

        bool isLeftMousePressed = Mouse.current.leftButton.isPressed;
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

            bool leftArrowHeld = Keyboard.current.leftArrowKey.isPressed;
            bool rightArrowHeld = Keyboard.current.rightArrowKey.isPressed;
            bool upArrowHeld = Keyboard.current.upArrowKey.isPressed;
            bool downArrowHeld = Keyboard.current.downArrowKey.isPressed;

            if (leftArrowHeld)
            {
                currentTransform.eulerAngles = transform.forward * rotateSpeed * Time.deltaTime;
                currentTransform.position = -transform.forward * moveSpeed * Time.deltaTime;
            }

            if (rightArrowHeld)
            {
                currentTransform.eulerAngles = transform.forward * rotateSpeed * Time.deltaTime;
                currentTransform.position = transform.forward * moveSpeed * Time.deltaTime;
            }

            if (upArrowHeld)
            {
                currentTransform.eulerAngles = transform.forward * rotateSpeed * Time.deltaTime;
                currentTransform.position = transform.forward * moveSpeed * Time.deltaTime;
            }

            if (downArrowHeld)
            {
                currentTransform.eulerAngles = transform.forward * rotateSpeed * Time.deltaTime;
                currentTransform.position = -transform.forward * moveSpeed * Time.deltaTime;
            }
        }

        //leftButton and rightButton do the same thing
        bool leftIsHeld = Mouse.current.leftButton.isPressed;

        if (leftIsHeld)
        {
            Debug.Log("Left mouse is held");
        }

        bool leftIsPressed = Mouse.current.leftButton.wasPressedThisFrame;
        if (leftIsPressed)
        {
            Debug.Log("Left mouse is pressed");
        }

        bool leftIsReleased = Mouse.current.leftButton.wasReleasedThisFrame;
        if (leftIsReleased)
        {
            Debug.Log("Left mouse is released");
        }

        //MINE
        //Vector3 currentPosition = 
        bool wIsPressed = Keyboard.current.wKey.isPressed;
        if (wIsPressed)
        {
            currentRotation.x += Time.deltaTime * rotateSpeed;
            transform.eulerAngles = currentRotation;

            currentPosition.y += Time.deltaTime * moveSpeed;
            transform.position = currentPosition;

            Debug.Log("w is pressed");
        }
        bool aIsPressed = Keyboard.current.aKey.isPressed;
        if (aIsPressed)
        {
            currentRotation.z -= Time.deltaTime * rotateSpeed;
            transform.eulerAngles = currentRotation;

            currentPosition.x -= Time.deltaTime * moveSpeed;
            transform.position = currentPosition;

            Debug.Log("a is pressed");
        }

        bool sIsPressed = Keyboard.current.sKey.isPressed;
        if (sIsPressed)
        {
            currentRotation.x -= Time.deltaTime * rotateSpeed;
            transform.eulerAngles = currentRotation;

            currentPosition.y -= Time.deltaTime * moveSpeed;
            transform.position = currentPosition;

            Debug.Log("s is pressed");
        }

        bool dIsPressed = Keyboard.current.dKey.isPressed;
        if (dIsPressed)
        {
            currentRotation.z += Time.deltaTime * rotateSpeed;
            transform.eulerAngles = currentRotation;

            currentPosition.x += Time.deltaTime * moveSpeed;
            transform.position = currentPosition;

            Debug.Log("d is pressed");
        }
    }
}



        