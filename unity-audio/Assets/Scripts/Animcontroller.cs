using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    public Animator TyAnimator;
    private bool isGrounded;

    void Update()
    {
        PlayerIsMoving();
    }

    public void PlayerIsMoving()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement.magnitude > 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);

            TyAnimator.SetBool("IsRunning", true);
        }
        else
        {
            TyAnimator.SetBool("IsRunning", false);
        }
    }

    public void TriggerJumping()
    {
        TyAnimator.SetBool("IsJumping", true); 
    }

    public void TriggerFalling()
    {
        TyAnimator.SetBool("IsFalling", true);
    }

    public void StopFalling()
    {
        TyAnimator.SetBool("IsFalling", false);
        TyAnimator.SetBool("IsJumping", false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            TyAnimator.SetBool("IsJumping", false); // Stop jump animation on landing
            TyAnimator.SetBool("IsFalling", false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
