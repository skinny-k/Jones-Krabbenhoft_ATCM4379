using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour
{
    [SerializeField] WaterDrop _waterDropPrefab;
    [SerializeField] Transform _origin;

    [SerializeField] float _minWaterValue = 0.75f;
    [SerializeField] float _maxWaterValue = 1.25f;

    void FixedUpdate()
    {
        if (Time.time % 1 == 0)
        {
            Instantiate(_waterDropPrefab, _origin.position, Quaternion.identity).WaterValue = Random.Range(_minWaterValue, _maxWaterValue);
        }
    }
}
