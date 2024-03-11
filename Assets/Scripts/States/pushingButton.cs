using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;

public class pushingButton : CharacterStateBase
{
    private ExtPlayerMovement pm;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pm = GetExtPlayerMovement(animator);
        animator.SetBool("pushingButton", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (pm.faceAngle == 90)
        {
            animator.SetBool("mirror",false);
        }
        else
        {
            animator.SetBool("mirror",true);
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //VultureDie ist der Button Click
        SoundManager.PlaySoundOnce(SoundManager.Sound.VultureDie, SoundAssets._fx,0.3f);
        animator.SetBool("canPress", false); 
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
