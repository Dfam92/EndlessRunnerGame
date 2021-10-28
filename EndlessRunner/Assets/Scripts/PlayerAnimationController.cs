using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerAnimationController : MonoBehaviour
{
    private PlayerController player;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
        player.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            player.enabled = true;
            animator.SetBool(PlayerAnimationConstants.PlayerEnable, true);
        }
        animator.SetBool(PlayerAnimationConstants.IsJumping, player.IsJumping);
    }
}
