using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerAnimationConstants
{
    public const string JumpMultiplier = "JumpMultiplier";
    public const string IsJumping = "isJumping";
    public const string PlayerEnable = "playerEnable";
    public const string StartRun = "startRun";
}

public class JumpAnimationState : StateMachineBehaviour
{
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // olha a duracao de animacao do pulo
        AnimatorClipInfo[] clips = animator.GetNextAnimatorClipInfo(layerIndex);
        if(clips.Length > 0)
        {
            AnimatorClipInfo jumpClipInfo = clips[0];
            // olha a duracao do pulo do gameplay
            PlayerController player = animator.transform.parent.GetComponent<PlayerController>();
            //setar o JumpMultiplier para que a duracao final da animacao de pulo seja = a duracao do pulo no game
            float multiplier = jumpClipInfo.clip.length / player.JumpDuration;
            animator.SetFloat(PlayerAnimationConstants.JumpMultiplier,multiplier);
        }

    }

}
