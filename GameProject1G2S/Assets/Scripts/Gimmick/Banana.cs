using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    private Animator animator;
    private bool isCheck;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isCheck)
        {
            isCheck = true;
            animator = collision.GetComponent<Animator>();
            collision.GetComponent<PlayerController>().enabled = false;

            animator.SetBool("isWalking", false);
            animator.SetBool("isDashing", false);
            animator.SetBool("isCrouching", false);
            animator.SetBool("isJumping", false);
            collision.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
        }
    }
}
