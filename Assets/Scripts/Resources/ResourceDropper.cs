using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDropper : MonoBehaviour
{
    [SerializeField] ResourceDrop _dropPrefab;
    [SerializeField] Transform _origin;
    [SerializeField] float _minValue = 0.75f;
    [SerializeField] float _maxValue = 1.25f;

    void FixedUpdate()
    {
        if (Time.time % 1 == 0)
        {
            ResourceDrop drop = Instantiate(_dropPrefab, _origin.position, Quaternion.identity);
            drop.Value = Random.Range(_minValue, _maxValue);
        }
    }
}
