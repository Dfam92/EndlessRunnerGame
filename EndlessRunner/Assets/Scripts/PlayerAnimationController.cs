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
    }
    // Update is called once per frame
    void Update()
    {
        animator.SetBool(PlayerAnimationConstants.IsJumping, player.IsJumping);
    }
}
