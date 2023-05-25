using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController cc;
    Vector3 velocity;
    float gravity = -9.81f;
    int speed;

    //Abilities
    int regularSpeed;
    int sprintSpeed;
    int jumpBoost;

    //Animation
    Animator animator;
    Vector3 lastPosition;


    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();

        //Abilities
        regularSpeed = 2;//gameObject.GetComponent<Abilities>().regularSpeed;
        sprintSpeed = 3;//gameObject.GetComponent<Abilities>().sprintSpeed;
        jumpBoost = 1;//gameObject.GetComponent<Abilities>().jumpBoost;

        //Animation
        animator = GetComponent<Animator>();
        lastPosition = gameObject.transform.position;
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            animator.SetBool("walk", true);
            animator.SetBool("idle", false);
            /*
            if (Input.GetAxis("Horizontal") > 0)
            {
                animator.SetFloat("direction", 1);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                animator.SetFloat("direction", -1);
            }
            */
        }
        else
        {
            animator.SetBool("walk", false);
            animator.SetBool("idle", true);
        }

        //Player actions
        if (cc.isGrounded)
        {
            //Jump
            if (Input.GetButton("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpBoost * -2f * gravity);
                animator.SetBool("jump", true);
            }
            else
            {
                animator.SetBool("jump", false);
            }
            //Sprint
            if (Input.GetButton("Fire3"))
            {
                speed = sprintSpeed;
                animator.SetBool("run", true);
            }
            else
            {
                speed = regularSpeed;
                animator.SetBool("run", false);
            }
            //Crouch
            if (Input.GetButton("Fire1"))
                animator.SetBool("crouch", true);
            else
                animator.SetBool("crouch", false);
        }

        //Move Player
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        cc.Move(move * Time.deltaTime * speed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
    }
}
