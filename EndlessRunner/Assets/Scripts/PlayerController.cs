using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedTurn;
    [SerializeField] private float speedForward;
    [SerializeField] private Vector3 limitBound;
    
    private float targetPosX;
   
    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        var targetPosition = transform.position;
        targetPosition.x = Mathf.Lerp(transform.position.x, targetPosX, Time.deltaTime * speedTurn);
        targetPosition += Vector3.forward * speedForward * Time.deltaTime;

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
}
