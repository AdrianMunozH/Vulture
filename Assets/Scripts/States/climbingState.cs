using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;

public class climbingState : CharacterStateBase
{
    private ExtPlayerMovement pm;

    private bool up;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pm = GetExtPlayerMovement(animator);
        pm.Rigidbody.velocity = Vector3.zero;
        pm.Rigidbody.useGravity = false;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (animator.IsInTransition(layerIndex))
        {
            animator.speed = 1;
            return;
        }
        
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
        

        if (pm.MoveUp && pm.MoveDown)
        {
            animator.speed = 0;
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            up = false;
            endSound();
            return;
        }

        if (!pm.MoveUp && !pm.MoveDown)
        {
            animator.speed = 0;
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            up = false;
            endSound();
            return;
        }

        if (pm.MoveUp)
        {
            animator.speed = 1;
            pm.transform.Translate(Vector3.up * pm.moveSpeed/3* Time.deltaTime);
            animator.SetBool("Up", true);
            up = true;
            playSound();
        }


        if (pm.MoveDown && !animator.GetBool("endLadder"))
        {
            animator.speed = 1;
            pm.transform.Translate(Vector3.down * pm.moveSpeed/3 * Time.deltaTime);
            animator.SetBool("Down", true);
            up = false;
            playSound();
        }
        
        
        if (pm.Jump)
        {
            animator.SetBool("isJumping",true);
            pm.faceAngle *= -1;
            pm.transform.rotation = Quaternion.Euler(0f, pm.faceAngle, 0f);
        }
        else
        {
            animator.SetBool("isJumping", false);
            
        }
        
    }
    public void playSound()
    {
        SoundManager.PlaySoundLoop(SoundManager.Sound.MoleboyLadder,SoundAssets._fx,Random.Range(0.07f, 0.13f),Random.Range(0.9f,1f));

    }public void endSound()
    {
        SoundManager.EndSoundLoop(SoundManager.Sound.MoleboyLadder);
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (up)
        {
            animator.SetBool("Up",false);
            
        }
        else
        {
            animator.SetBool("Down",false);
        }
        endSound();
        // erst nach der nächsten animation rein ???
        // **test ** pm.Rigidbody.useGravity = true;    
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
