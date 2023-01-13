using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerMovement : MonoBehaviour
{
        
    float horizontalMove = 0;
    public float runSpeed = 40f;    
    public Animator animator;

    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement


    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;

    private void Awake() {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed * Time.fixedDeltaTime;
        //Debug.Log()
        if (Mathf.Abs(horizontalMove) > 0)
            animator.SetInteger("AnimState", 2);
        else
            animator.SetInteger("AnimState", 0);
    }


    void FixedUpdate() {
        //controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(horizontalMove * 10f, m_Rigidbody2D.velocity.y);
        // And then smoothing it out and applying it to the character
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        // If the input is moving the player right and the player is facing left...
        if (horizontalMove > 0 && !m_FacingRight) {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (horizontalMove < 0 && m_FacingRight) {
            // ... flip the player.
            Flip();
        }

    }
    		
    private void Flip() {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);

        /*
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        */
    }

}
