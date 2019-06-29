using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject dancingPikminPrefab;
    public Transform[] spawnPoints;
    int currentSpawnpoint;

    
    public void SpawnDancingPikmin()
    {
        if(currentSpawnpoint < spawnPoints.Length)
        {
            Instantiate(dancingPikminPrefab, spawnPoints[currentSpawnpoint].position, spawnPoints[0].rotation);
            currentSpawnpoint += 1;
        }
    }
}
