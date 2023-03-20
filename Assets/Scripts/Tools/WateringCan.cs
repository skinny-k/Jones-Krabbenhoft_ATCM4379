using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour
{
    [SerializeField] ResourceDrop _waterDropPrefab;
    [SerializeField] Transform _origin;

    [SerializeField] float _minWaterValue = 0.75f;
    [SerializeField] float _maxWaterValue = 1.25f;

    void FixedUpdate()
    {
        if (Time.time % 1 == 0)
        {
            ResourceDrop waterDrop = Instantiate(_waterDropPrefab, _origin.position, Quaternion.identity);
            waterDrop.Value = Random.Range(_minWaterValue, _maxWaterValue);
            waterDrop.Resource = ResourceDrop.ResourceType.Water;
        }
    }
}
