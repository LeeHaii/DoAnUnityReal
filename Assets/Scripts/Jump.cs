using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    [SerializeField] private InputActionProperty jumpAction;
    [SerializeField]private float jumpForce = 5f;
    public float gravity = 14.0f;
    private float verticalVelocity;
    [SerializeField] private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jumpie();
    }

    private void Jumpie()
    {
        if (characterController.isGrounded)
        {
            Debug.Log("isGrounded: " + characterController.isGrounded.ToString());
            verticalVelocity = -gravity * Time.deltaTime;
            Debug.Log("VerticalVelocity now is: " + verticalVelocity.ToString());
            if (jumpAction.action.WasPressedThisFrame())
            {
                verticalVelocity = jumpForce;
                Debug.Log("Jumped");
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
            Debug.Log("Falling");
        }
        Vector3 moveVector = new Vector3(0, verticalVelocity, 0);
        characterController.Move(moveVector * Time.deltaTime);
    }
}
