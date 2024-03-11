using UnityEngine;
using UnityEngine.Audio;

namespace States
{
    public class RunningState : CharacterStateBase
    {
        private float startFalling;
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            
            ExtPlayerMovement pm = GetExtPlayerMovement(animator);
            animator.SetBool("isGrounded",IsGrounded());
            
            if (IsPushing() == 0)
            {
                animator.SetBool("isPushing", false);
                animator.SetBool("isLadder", false);
            } else if (IsPushing() == 1)
            {
                animator.SetBool("isPushing", true);
            }
            else if (IsPushing() == 2)
            {
                animator.SetBool("isLadder", true);
            }
            else
            {
                Debug.Log("fehler der isPushing Methode, sollte nur  0|1|2 sein");
            }
            animator.SetFloat("startFalling", pm.Rigidbody.velocity.y);

            if (pm.MoveLeft && pm.MoveRight)
            {
                animator.SetBool("isRunning",false);
                endSound(PlayerSoundNumber(animator));
                return;
                
            }
        
            if (!pm.MoveLeft && !pm.MoveRight)
            {
                endSound(PlayerSoundNumber(animator));
                animator.SetBool("isRunning",false);
                return;
            }
            if (pm.MoveRight)
            {
                pm.faceAngle = 90f;
                pm.transform.Translate(Vector3.forward * pm.moveSpeed*Time.deltaTime);
                pm.transform.rotation = Quaternion.Euler(0f,pm.faceAngle,0f);
                animator.SetBool("isRunning",true);
                playSound(PlayerSoundNumber(animator));
            }


            if (pm.MoveLeft)
            {
                pm.faceAngle = -90f;
                pm.transform.Translate(Vector3.forward * pm.moveSpeed * Time.deltaTime);
                pm.transform.rotation = Quaternion.Euler(0f,pm.faceAngle,0f);
                animator.SetBool("isRunning",true);
                playSound(PlayerSoundNumber(animator));
            }
            
            if (pm.Jump)
            {
                animator.SetBool("isJumping",true);
            }
            else
            {
                animator.SetBool("isJumping", false);
            }
        }

        public void playSound(int nmb)
        {
            
            if (nmb == 1)
            {
                SoundManager.PlaySoundLoop(SoundManager.Sound.RatMove,SoundAssets._fx,Random.Range(0.1f, 0.13f),Random.Range(0.9f,1f));
            } else if (nmb == 2)
            {
                SoundManager.PlaySoundLoop(SoundManager.Sound.MoleboyMove,SoundAssets._fx,Random.Range(0.10f, 0.20f),Random.Range(0.9f,1f));
            }
            else
            {
                SoundManager.PlaySoundLoop(SoundManager.Sound.VultureMove,SoundAssets._fx);
            }
        }public void endSound(int nmb)
        {
            if (nmb == 1)
            {
                SoundManager.EndSoundLoop(SoundManager.Sound.RatMove);
            } else if (nmb == 2)
            {
                SoundManager.EndSoundLoop(SoundManager.Sound.MoleboyMove);
            }
            else
            {
                SoundManager.EndSoundLoop(SoundManager.Sound.VultureMove);
            }
        }
        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
         endSound(PlayerSoundNumber(animator));   
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
}
