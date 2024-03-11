using UnityEngine;

namespace States
{
    public class IdleState : CharacterStateBase
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
            
        
            animator.SetBool("isGrounded",IsGrounded());
            animator.SetFloat("startFalling", pm.Rigidbody.velocity.y);
        
            if (pm.MoveRight)
            {
                animator.SetBool("isRunning",true);
            }


            if (pm.MoveLeft)
            {
                animator.SetBool("isRunning",true);
            }
            if (pm.Jump)
            {
                animator.SetBool("isJumping",true);
            }
            else
            {
                animator.SetBool("isJumping", false);
            }
            if (pm.DoAction)
            {
                animator.SetBool("pushingButton", true);
            }
            else
            {
                animator.SetBool("pushingButton", false);
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
