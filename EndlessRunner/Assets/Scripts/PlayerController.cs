using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedTurn;
    [SerializeField] private float speedForward;
    [SerializeField] private Vector3 limitBound;

    [Header("Jump")]

    [SerializeField] private float jumpDistanceZ = 5;
    [SerializeField] private float jumpHeightY = 2;
    bool isJumping;
    float jumpStartZ;

    public float JumpDuration => jumpDistanceZ / speedForward;

    

    [Header("Roll")]

    [SerializeField] private float rollDistanceZ;
    [SerializeField] private Collider rollCollider;
    [SerializeField] private Collider normalCollider;
    private bool isRolling;
    private float rollStartZ;

    public float RollDuration => rollDistanceZ / speedForward;


    bool isDead;
    private float targetPosX;
    Vector3 initialPos;


    public bool IsJumping { get => isJumping; private set => isJumping = value; }
    public bool IsDead { get => isDead; set => isDead = value; }
    public bool IsRolling { get => isRolling; private set => isRolling = value; }

    private bool CanJump => !IsJumping && !IsRolling;
    private bool CanRoll => !IsJumping && !IsRolling;

    private void Awake()
    {
        initialPos = transform.position;
        //StopRoll();
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerJump();
        PlayerRoll();
        ProcessRoll();
    }

    private void PlayerMovement()
    {
        var targetPosition = transform.position;
        targetPosition.x = Mathf.Lerp(transform.position.x, targetPosX, Time.deltaTime * speedTurn);
        targetPosition += Vector3.forward * speedForward * Time.deltaTime;
        targetPosition.y = ProcessJump();

        if (Input.GetKeyDown(KeyCode.A) && targetPosX != -limitBound.x)
        {
            targetPosX += -limitBound.x;
        }
        else if (Input.GetKeyDown(KeyCode.D) && targetPosX != limitBound.x)
        {
            targetPosX += limitBound.x;
        }
        transform.position = targetPosition;
    }

    private void PlayerJump()
    {
        if(Input.GetKeyDown(KeyCode.W) && CanJump)
        {
            IsJumping = true;
        }
    }

    private void PlayerRoll()
    {
        if(Input.GetKeyDown(KeyCode.S) && CanRoll)
        {
            IsRolling = true;
            rollStartZ = transform.position.z;
            normalCollider.enabled = false;
            rollCollider.enabled = true;
        }
    }
    private void StopRoll()
    {
        IsRolling = false;
        normalCollider.enabled = true;
        rollCollider.enabled = false;
    }

    private void ProcessRoll()
    {
        if(IsRolling)
        {
            float percent = (transform.position.z - rollStartZ) / rollDistanceZ;
            if(percent >= 1)
            {
                StopRoll();
            }
        }
    }

    private float ProcessJump()
    {
        float deltaY = 0;
        if (IsJumping)
        {
            float jumpCurrentProgress = transform.position.z - jumpStartZ;
            float jumpPercent = jumpCurrentProgress / jumpDistanceZ;
            if (jumpPercent >= 1)
            {
                IsJumping = false;
            }
            else
            {
                deltaY = Mathf.Sin(Mathf.PI * jumpPercent)*jumpHeightY;
            }
        }
        return initialPos.y + deltaY;
    }
   
}
