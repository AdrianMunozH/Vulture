using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;

public class PushState : CharacterStateBase
{
    private ExtPlayerMovement pm;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pm = GetExtPlayerMovement(animator);
        //pm. = true;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        animator.SetBool("isGrounded", IsGrounded());
        if (IsPushing() == 0)
        {
            animator.SetBool("isPushing", false);
        } else if (IsPushing() == 1)
        {
            animator.SetBool("isPushing", true);
        }
        else
        {
            Debug.Log("fehler der isPushing Methode, sollte nur  0|1|2 sein");
        }
        
        if (pm.MoveLeft && pm.MoveRight)
        {
            animator.SetBool("isRunning", false);
            endSound(PlayerSoundNumber(animator));
            return;
        }

        if (!pm.MoveLeft && !pm.MoveRight)
        {
            animator.SetBool("isRunning", false);
            endSound(PlayerSoundNumber(animator));
            return;
        }
        pm.BoxCollider.enabled = true;

        if (pm.MoveRight)
        {
            pm.faceAngle = 90f;
            pm.transform.Translate(Vector3.forward * pm.moveSpeed/3* Time.deltaTime);
            pm.transform.rotation = Quaternion.Euler(0f, pm.faceAngle, 0f);
            animator.SetBool("isRunning", true);
            playSound(PlayerSoundNumber(animator));
        }


        if (pm.MoveLeft)
        {
            pm.faceAngle = -90f;
            pm.transform.Translate(Vector3.forward * pm.moveSpeed/3 * Time.deltaTime);
            pm.transform.rotation = Quaternion.Euler(0f, pm.faceAngle, 0f);
            animator.SetBool("isRunning", true);
            playSound(PlayerSoundNumber(animator));
        }
    }
    public void playSound(int nmb)
    {
            
        if (nmb == 2)
        {
            SoundManager.PlaySoundLoop(SoundManager.Sound.MoleboyPush,SoundAssets._fx,Random.Range(0.08f, 0.1f),Random.Range(0.9f,1f));
            SoundManager.PlaySoundLoop(SoundManager.Sound.BoxSound,SoundAssets._fx,0.05f);
        }
    }
    public void endSound(int nmb)
    {
        if (nmb == 1)
        {
            SoundManager.EndSoundLoop(SoundManager.Sound.RatPush);
            SoundManager.EndSoundLoop(SoundManager.Sound.StoneSound);
        } else if (nmb == 2)
        {
            SoundManager.EndSoundLoop(SoundManager.Sound.MoleboyPush);
            SoundManager.EndSoundLoop(SoundManager.Sound.BoxSound);
        }
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pm.BoxCollider.enabled = false;
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
