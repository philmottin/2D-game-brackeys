using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    
    float horizontalMove = 0;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    public Animator animator;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        /*
         * The jump animation only works with the 'Has exit time' checked on both transitions
         * OR changed CharacterController2D.cs on line 130 
         * // Add a vertical force to the player. from false to true
		 *	m_Grounded = false;
		 *
		 * // best solution, change this radius
         * OR const float k_GroundedRadius = .2f; changed to 0.05 - line 
         */
        if (Input.GetButtonDown("Jump")) {
            jump = true;
            animator.SetBool("isJumping", true);
        }
        if (Input.GetButtonDown("Crouch")) {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch")) {
            crouch = false;
        }
    }

    public void onLanding() {
        animator.SetBool("isJumping", false);
    }
    public void onCrouching(bool isCrouching) {
        animator.SetBool("isCrouching", isCrouching);
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
