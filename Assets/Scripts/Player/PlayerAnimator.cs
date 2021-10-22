using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Move(float horizontalMove)
    {
        if(horizontalMove != 0f)
        {
            animator.SetBool("move", true);
            animator.SetBool("idle", false);
        }
        else
        {
            animator.SetBool("move", false);
            animator.SetBool("idle", true);
        }
    }

    public void Jump(bool isJump)
    {
        Debug.Log(isJump);
        animator.SetBool("jump", isJump);
    }
}
