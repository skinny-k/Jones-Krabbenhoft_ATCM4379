using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDrop : MonoBehaviour
{
    public enum ResourceType { Water, Fertilizer }

    [SerializeField] float _lifetime = 5f;
    [SerializeField] public ResourceType Resource;
    [SerializeField] public float Value = 1f;
    float _spawnTime = 0;

    void Start()
    {
        _spawnTime = Time.time;
    }

    void OnTriggerEnter(Collider other)
    {
        other?.GetComponent<Plant>()?.AddResource(Resource, Value);
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
