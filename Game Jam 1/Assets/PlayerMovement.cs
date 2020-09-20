﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public Vector3 velocity;
    public float g = -9.81f;



    public LevelManagement levelManagement;
    // Update is called once per frame
    void Update()
    {

        if (!levelManagement.isGameOver()) 
        {
            if (controller.isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += g * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
