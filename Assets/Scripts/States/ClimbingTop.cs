using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;
using UnityEngine.ProBuilder;

public class ClimbingTop : CharacterStateBase
{
    private ExtPlayerMovement pm;
    private float time;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pm = GetExtPlayerMovement(animator);
        pm.Rigidbody.useGravity = false;
        time = Time.time;
    }


    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    
        animator.SetBool("testDelete",false);
        pm.frontCollider.enabled = false;
        pm.frictionCollider.enabled = false;
        
        int currTime =(int) (Time.time - time);

        float val = currTime;
        if (val <= 2)
        {
            pm.transform.Translate(Vector3.up* pm.moveSpeed/12* Time.deltaTime);
        }

        if (val >= 2)
        {
            pm.transform.Translate(Vector3.forward* pm.moveSpeed/10* Time.deltaTime);
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pm.Rigidbody.useGravity = true;
        pm.frontCollider.enabled = true;
        animator.applyRootMotion = false;
        animator.SetBool("Down",false);
        animator.SetBool("Up",false);
        pm.frictionCollider.enabled = true;
        
    }

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
