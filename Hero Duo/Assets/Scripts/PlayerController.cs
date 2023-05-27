using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector2 playerVelocity;
    //private bool groundedPlayer;

    [SerializeField]
    private float playerSpeed = 3.0f;

    //private float jumpHeight = 1.0f;
    //private float gravityValue = -9.81f;

    private Vector2 movementInput = Vector2.zero;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    void Update()
    {
        // lock z axis
        //Vector3 pos = transform.position;
        //pos.z = 0;
        //transform.position = pos;

        // lock y rotation
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        //transform.Rotate(transform.rotation.x, 0, transform.rotation.z);

        //GetComponent<Transform>().rotation.y = 0;
        // W and S changes Z position
        //GetComponent<Transform>().position.z = 0;

        //groundedPlayer = controller.isGrounded;
        //if (groundedPlayer && playerVelocity.y < 0)
        //{
        //    playerVelocity.y = 0f;
        //}
        //controller.attachedRigidbody.rotation = Quaternion.Euler(0, 0, 0);
        //controller.transform.rotation = Quaternion.Euler(0, 0, 0);
        //this.GetComponent<SpriteRenderer>().gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        //controller.transform.eulerAngles.y = 0;

        Vector2 move = new Vector2(movementInput.x, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector2.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        //if (Input.GetButtonDown("Jump") && groundedPlayer)
        //{
        //    playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        //}

        //playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}