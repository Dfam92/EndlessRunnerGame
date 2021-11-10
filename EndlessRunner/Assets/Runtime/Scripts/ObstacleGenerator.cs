using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private Obstacles[] obstaclesPrefabs;

    private Obstacles currentObstacle;

    public void SpawnObstacle()
    {
        Obstacles prefab = obstaclesPrefabs[Random.Range(0, obstaclesPrefabs.Length)];
        currentObstacle = Instantiate(prefab, transform);
        currentObstacle.transform.localPosition = Vector3.zero;
        currentObstacle.transform.rotation = Quaternion.identity;
        currentObstacle.SpawnDecorations();
    }
}
