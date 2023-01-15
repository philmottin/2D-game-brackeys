using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMovement_TopDownShooting : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;

    public Transform interactor;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x != 0 || movement.y != 0) {
            animator.SetFloat("LastHorizontal", movement.x);
            animator.SetFloat("LastVertical", movement.y);
        }

        if (movement.x > 0)
            interactor.localRotation = Quaternion.Euler(0, 0, 90);
        if (movement.x < 0)
            interactor.localRotation = Quaternion.Euler(0, 0, -90);
        if (movement.y > 0)
            interactor.localRotation = Quaternion.Euler(0, 0, 180);
        if (movement.y < 0)
            interactor.localRotation = Quaternion.Euler(0, 0, 0);

    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
