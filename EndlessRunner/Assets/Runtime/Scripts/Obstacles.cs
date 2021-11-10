using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private DecorationSpawner[] decorationSpawners;

    public void SpawnDecorations()
    {
        foreach(var decorationSpawner in decorationSpawners)
        {
            decorationSpawner.SpawnDecorations();
        }
    }
}
