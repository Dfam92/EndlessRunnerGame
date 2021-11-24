using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private float rotateSpeed;

    private void Update()
    {
        transform.Rotate(Vector3.forward* rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider player)
    {
        Destroy(this.gameObject);
    }
}
