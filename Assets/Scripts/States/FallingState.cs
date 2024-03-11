using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;

public class FallingState : CharacterStateBase
{
    private ExtPlayerMovement pm;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pm = GetExtPlayerMovement(animator);
       
    }    

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
        pm.transform.Translate(Vector3.forward * pm.Rigidbody.velocity.magnitude* 0.3f *Time.deltaTime);
        animator.SetBool("isGrounded",IsGrounded());
        animator.SetFloat("startFalling",pm.Rigidbody.velocity.y);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    /*
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat("startFalling", pm.Rigidbody.velocity.y);
    }
    */

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
