using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public class RunningStateVulture : CharacterStateBase
    {
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            PlayerMovement pm = GetPlayerMovement(animator);

            if (pm.MoveLeft && pm.MoveRight)
            {
                animator.SetBool("isRunning",false);
                return;
            }
        
            if (!pm.MoveLeft && !pm.MoveRight)
            {
                animator.SetBool("isRunning",false);
                return;
            }
            if (pm.MoveRight)
            {
                pm.faceAngle = 90f;
                pm.transform.Translate(Vector3.forward * pm.moveSpeed*Time.deltaTime);
                pm.transform.rotation = Quaternion.Euler(0f,pm.faceAngle,0f);
                animator.SetBool("isRunning",true);
            }


            if (pm.MoveLeft)
            {
                pm.faceAngle = -90f;
                pm.transform.Translate(Vector3.forward * pm.moveSpeed * Time.deltaTime);
                pm.transform.rotation = Quaternion.Euler(0f,pm.faceAngle,0f);
                animator.SetBool("isRunning",true);
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
}

