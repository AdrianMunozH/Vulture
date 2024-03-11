using UnityEngine;
using UnityEngine.Audio;

namespace States
{
    public class RunJumpState : CharacterStateBase
    {
        private float duration;

        private ExtPlayerMovement pm;
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            duration = Time.time;
            pm = GetExtPlayerMovement(animator);
            pm.Rigidbody.useGravity = true; // **test**
            // Jump 
            if (animator.GetBool("isJumping"))
            {
                playSound(PlayerSoundNumber(animator));
                pm.Rigidbody.AddForce(Vector3.up * pm.jumpForce);
            }
        }
        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            pm.transform.Translate(Vector3.forward * pm.moveSpeed*Time.deltaTime);
            if (IsPushing() == 0)
            {
                animator.SetBool("isLadder", false);
            } else if (IsPushing() == 2)
            {
                animator.SetBool("isLadder", true);
            }
            else
            {
                Debug.Log("fehler der isPushing Methode, sollte nur  0|1|2 sein");
            }
            
            animator.SetBool("isGrounded",IsGrounded());
        
            //Debug.Log(Time.time +  ": time : " + duration +": duration " + stateInfo.length + ": animation");
            if (Time.time - duration <= stateInfo.length)
            {
                animator.SetBool("isJumping", false);
            }
            animator.SetFloat("startFalling",pm.Rigidbody.velocity.y);
        }
        private void playSound(int nmb)
        {
            if (nmb == 1)
            {
                SoundManager.PlaySoundOnce(SoundManager.Sound.RatJump,SoundAssets._fx,0.05f);
               
            } else if (nmb == 2)
            {
                SoundManager.PlaySoundOnce(SoundManager.Sound.MoleboyJump,SoundAssets._fx,0.1f);
                SoundManager.PlaySoundOnce(SoundManager.Sound.MoleboyJumpNoise,SoundAssets._fx,0.1f);
            }
        }
    
    
        // isGround check erst hier im exit ??? 
    
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
