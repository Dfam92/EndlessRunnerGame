using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGenerator : MonoBehaviour
{
    [SerializeField] private PowerUps powerUps;
    private float xBasePos = 1.5f;
    private float[] randomXPos = new float[3];

    private void Start()
    {
        SpawnPowerUp();
    }

    private void SpawnPowerUp()
    {
        
        {
            float[] randomXPos = { -xBasePos, 0f, xBasePos };
            int index = Random.Range(0, randomXPos.Length);
            transform.position = new Vector3(randomXPos[index], transform.position.y, transform.position.z);
            Instantiate(powerUps, transform);
        }
        
    }
}
