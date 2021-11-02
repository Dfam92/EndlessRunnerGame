using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerController player;
    [SerializeField] private GameMode gameMode;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacles"))
        {
            player.IsDead = true;
            animator.SetTrigger(PlayerAnimationConstants.IsDead);
            gameMode.OnGameOver();
        }
    }
}

