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
    private float targetPosX;
    Vector3 initialPos;

    public bool IsJumping { get => isJumping; private set => isJumping = value; }
    public float JumpDuration => jumpDistanceZ / speedForward;

    private void Awake()
    {
        initialPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerJump();
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
        if(Input.GetKeyDown(KeyCode.W) && !IsJumping)
        {
            IsJumping = true;
            jumpStartZ = transform.position.z;
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
