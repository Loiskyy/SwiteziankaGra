using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  
    public CharacterController controller;
    public float playerspeed = 12f;
    public float playergravity = -9.81f;

    public Transform groundcheck;
    public float groundDistance =0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    Vector3 velocity;
    // Update is called once per frame
    void Update()
    {   
       isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);
       
       if (isGrounded && velocity.y < 0) {
        velocity.y = -2f;
       }

       float x = Input.GetAxis("Horizontal");
       float z = Input.GetAxis("Vertical");
       Vector3 move = transform.right * x + transform.forward * z;
       controller.Move(move * playerspeed * Time.deltaTime);
       velocity.y += playergravity * Time.deltaTime;

       controller.Move(velocity * Time.deltaTime);
    }
}
