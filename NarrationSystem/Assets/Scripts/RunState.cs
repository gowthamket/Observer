using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.IsInTransition(layerIndex))
        {
            return;
        }
        if (!animator.GetBool("isRunning") && animator.GetBool("isWalking"))
        {
            animator.CrossFadeInFixedTime("Walk", .1f, layerIndex);
        }
        else if (!animator.GetBool("isRunning"))
        {
            animator.CrossFadeInFixedTime("Idle", .1f, layerIndex);
        }
        else if (animator.GetBool("isJumping"))
        {
            int jumpCount = animator.GetInteger("jumpCount");

            if (jumpCount == 1 || jumpCount == 0)
            {
                animator.CrossFadeInFixedTime("Jump", .1f);
            }
            else if (jumpCount == 2)
            {
                animator.CrossFadeInFixedTime("Jump 2", .1f);
            }
            else if (jumpCount == 3)
            {
                animator.CrossFadeInFixedTime("Jump 3", .1f);
            }
        }
        // use else if for statemachine
        // else if (animator.GetBool("isAttacking"))
        // {
        //     animator.CrossFadeInFixedTime("Attack1", .1f);
        // }
        if (animator.GetBool("isAttacking") && layerIndex == 1)
        {
            animator.CrossFadeInFixedTime("Attack", .1f, layerIndex);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
