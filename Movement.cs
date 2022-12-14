using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 16f;
    Vector3 velocity;
    public float gravity = -19.62f;
    public bool IsWall;
    public Transform groundCheck;
    public float groundDistance = 0.8f;
    public LayerMask groundMask;
    public bool isgrounded;
    public float downV = 6f;
    public float jumpHeight = 3f;

    public Transform playertrans;
    public WallRunning wallScript;
    public bool canjump1 = false;

    void Update()
    {
        isgrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        if (isgrounded && velocity.y < 0)
        {
            velocity.y = -downV;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
             speed = 22f; 
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 16f;
        }
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump")&&(isgrounded || canjump1))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                if (canjump1 == true)
                {
                    canjump1 = false;
                }
        }
        if (IsWall)
        {
            downVRes2();
        }
        if (!IsWall)
        {
            GvAdd();
        }
        

        
        controller.Move(velocity * Time.deltaTime);
    }
    public void downVRes2()
    {
        velocity.y += gravity/2 *Time.deltaTime;
    }
    public void GvAdd()
    {
        velocity.y += gravity * Time.deltaTime;
    }
}
