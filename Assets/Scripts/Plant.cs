using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Plant : MonoBehaviour
{
    [SerializeField] protected GameObject _sprout;
    [SerializeField] protected GameObject _bush;
    [SerializeField] protected GameObject _deadBush;

    protected int _growStage = 0;

    [SerializeField] float _waterNeeded = 3f;

    float _currentWater = 0f;
    
    public abstract void Grow();

    public virtual void AddWater(float amount)
    {
        _currentWater += amount;

        if (_currentWater >= _waterNeeded && _growStage == 0)
        {
            Grow();
        }
    }
}
