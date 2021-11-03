using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private Obstacles[] obstaclesPrefabs;

    private void Start()
    {
        Instantiate(obstaclesPrefabs[Random.Range(0,obstaclesPrefabs.Length)], transform);
    }
}
