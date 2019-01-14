using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    Rigidbody2D rb;
    public float x = 3;
    public float y = 0;

    private void Start()
    {
        //get our rigidbody so we can apply a force
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        //horizontal movement input (A, D keys)
        //don't need this if we are just pushing the character forward
        //horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        //if the space bar is press jump on the next fixed update Move()
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        //Crouch controls
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        //push our player forward
        //TODO move this to the character controller
        //     and only addForce if the player is grounded
        rb.AddForce(new Vector2(runSpeed, y));

    }

    void FixedUpdate()
    {
        // Move our character
        //TODO redo the Move() method, we dont need to use horizontalMove controls
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

        //reset jump
        jump = false;
    }
}