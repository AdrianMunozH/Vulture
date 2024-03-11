using UnityEngine;

namespace States
{
    public class JumpFallState : CharacterStateBase
    {
        private ExtPlayerMovement pm;
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            playSound(PlayerSoundNumber(animator));

        }
        private void playSound(int nmb)
        {
            if (nmb == 1)
            {
                SoundManager.PlaySoundOnce(SoundManager.Sound.MoleboyLanding,SoundAssets._fx,0.05f);
               
            } else if (nmb == 2)
            {
                SoundManager.PlaySoundOnce(SoundManager.Sound.MoleboyLanding,SoundAssets._fx,0.1f);
            }
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        
            pm = GetExtPlayerMovement(animator);
            if (pm.gameObject.name == "MoleBoyNew")
            {
                pm.transform.Translate(Vector3.forward * pm.moveSpeed*0.5f*Time.deltaTime);
            }
            
            //    
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
