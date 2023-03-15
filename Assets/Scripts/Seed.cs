using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : ActivatedItem
{
    [SerializeField] Plant _plantToSpawn;
    [SerializeField] Transform _spawnLocation;

    public void SpawnPlant()
    {
        Instantiate(_plantToSpawn, _spawnLocation.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
