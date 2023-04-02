using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedDispenser : MonoBehaviour
{
    [SerializeField] Seed _seedToSpawn;
    [SerializeField] Transform _spawnTransform;

    public void DispenseSeed()
    {
        Instantiate(_seedToSpawn, _spawnTransform.position, Quaternion.identity);
    }
}
