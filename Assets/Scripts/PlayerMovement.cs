using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Identifies which player this belongs to
    public int playerNumber = 1;

    // How quickly player moves forward and back
    public float speed = 10f;

    // How quickly player rotates (degrees per second)
    public float rotationSpeed = 180f;

    private Rigidbody body;

	// Use this for initialization
	void Start ()
    {
        // Retrieve reference to this GameObject's Rigidbody component
        body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Get movement input value
        float movementInput = GetMovementInput();

        // Determine amount to move based on current forward direction and speed
        Vector3 movement = transform.forward * movementInput * speed * Time.deltaTime;

        // Move our Rigidbody to this position
        body.MovePosition(body.position + movement);

        // Get rotation input value
        float rotationInput = GetRotationInput();

        // Determine number of degrees to turn based on rotation speed
        float degreesToTurn = rotationInput * rotationSpeed * Time.deltaTime;

        // Get Quaternion equivalent of this amount of rotation around the y-axis
        Quaternion rotation = Quaternion.Euler(0f, degreesToTurn, 0f);

        // Rotate our Rigidbody by this amount
        body.MoveRotation(body.rotation * rotation);
	}

    // Returns input values of 0, 1 or -1 based on whether Player tries to move forward or back
    float GetMovementInput()
    {
        // Player 1 moves forward and back with W and S; Player 2 with Up and Down arrows
        KeyCode positiveKey = playerNumber == 1 ? KeyCode.W : KeyCode.UpArrow;
        KeyCode negativeKey = playerNumber == 1 ? KeyCode.S : KeyCode.DownArrow;

        if (Input.GetKey(positiveKey))
        {
            return 1f;
        }
        else if (Input.GetKey(negativeKey))
        {
            return -1f;
        }
        else
        {
            return 0f;
        }
    }

    // Returns input values of 0, 1 or -1 based on whether Player tries to rotate right or left
    float GetRotationInput()
    {
        // Player 1 rotates with A and D; Player 2 with Left and Right arrows 
        KeyCode positiveKey = playerNumber == 1 ? KeyCode.D : KeyCode.RightArrow;
        KeyCode negativeKey = playerNumber == 1 ? KeyCode.A : KeyCode.LeftArrow;

        if (Input.GetKey(positiveKey))
        {
            return 1f;
        }
        else if (Input.GetKey(negativeKey))
        {
            return -1f;
        }
        else
        {
            return 0f;
        }
    }
}