using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private float armZ;
    [ExecuteAlways]
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = player.transform.position;

        currentPosition.z = targetPosition.z + armZ;
        transform.position = currentPosition;
    }
}
