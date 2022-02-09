using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    public CharacterController controller;

    public float gravity = -9.81f;
    Vector3 velocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(controller.isGrounded)
        {
            velocity.y = -1f;
        }
        else if(!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
