using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Plant : MonoBehaviour
{
    [Header("Visual Settings")]
    [SerializeField] protected GameObject _sprout;
    [SerializeField] protected GameObject _bush;
    [SerializeField] protected GameObject _deadBush;

    [Header("Grow Settings")]
    [SerializeField] float _waterNeeded = 3f;
    [SerializeField] float _fertilizerNeeded = 3f;

    [Header("Initialization Settings")]
    [SerializeField] float _checkRadius = 0.1f;
    [SerializeField] LayerMask _interactionMask;

    protected PlanterNode _planter;
    protected int _growStage = 0;
    protected bool _fertilized = false;

    protected float _currentWater = 0f;
    protected float _currentFertilizer = 0f;
    
    public abstract void Grow();
    public abstract void ProgressDay();

    protected virtual void OnEnable()
    {
        DayManager.DayChanged += ProgressDay;
    }

    protected virtual void OnDisable()
    {
        DayManager.DayChanged -= ProgressDay;
    }

    void Awake()
    {
        Collider[] collidersInside = Physics.OverlapSphere(transform.position, _checkRadius, _interactionMask);
        Debug.Log(collidersInside.Length);

        foreach (Collider collider in collidersInside)
        {
            if (!collider.isTrigger)
            {
                _planter = collider.GetComponent<PlanterNode>();
                _planter.SetPlant(this);
            }
        }
    }
    
    public virtual void AddResource(ResourceDrop.ResourceType resource, float amount)
    {
        switch (resource)
        {
            case ResourceDrop.ResourceType.Water:
                _currentWater += amount;

                if (_currentWater >= _waterNeeded && _growStage == 0)
                {
                    Grow();
                }
                break;
            case ResourceDrop.ResourceType.Fertilizer:
                _currentFertilizer += amount;

                if (_currentFertilizer >= _fertilizerNeeded && _growStage == 1)
                {
                    _fertilized = true;
                    _planter.SetFertilizedMaterial(_fertilized);
                }
                break;
        }
    }
}
