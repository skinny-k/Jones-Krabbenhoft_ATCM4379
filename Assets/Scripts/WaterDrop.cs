using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    [SerializeField] float _lifetime = 5f;
    public float WaterValue = 1f;
    float _spawnTime = 0;
    
    void Start()
    {
        _spawnTime = Time.time;
    }
    
    void OnTriggerEnter(Collider other)
    {
        other?.GetComponent<Plant>().AddWater(WaterValue);
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (Time.time - _spawnTime >= _lifetime)
        {
            Destroy(gameObject);
        }
    }
}
