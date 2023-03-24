using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [Header("Visual Settings")]
    [SerializeField] protected GameObject _sprout;
    [SerializeField] protected GameObject _bush;
    [SerializeField] protected GameObject _deadBush;

    [Header("Grow Settings")]
    [SerializeField] float _waterNeeded = 3f;
    [SerializeField] float _fertilizerNeeded = 3f;
    [SerializeField] Weed _weedPrefab;
    [SerializeField] int _maxWeedsPerDay = 3;
    [SerializeField] int _weedThreshold = 2;
    [SerializeField] float _chanceToSpawnWeed = 0.4f;
    [SerializeField] float _chanceToSpawnInsects = 0.25f;

    [Header("Initialization Settings")]
    [SerializeField] float _checkRadius = 0.1f;
    [SerializeField] LayerMask _interactionMask;

    protected PlanterNode _planter;
    public int GrowStage { get; private set; } = 0;
    protected bool _fertilized = false;
    protected int _daysSinceLastWeed = 0;

    protected float _currentWater = 0f;
    protected float _currentFertilizer = 0f;

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

                if (_currentWater >= _waterNeeded && GrowStage == 0)
                {
                    Grow();
                }
                break;
            case ResourceDrop.ResourceType.Fertilizer:
                _currentFertilizer += amount;

                if (_currentFertilizer >= _fertilizerNeeded && GrowStage == 1)
                {
                    _fertilized = true;
                    _planter.SetFertilizedMaterial(_fertilized);
                }
                break;
        }
    }

    public virtual void Grow()
    {
        switch (GrowStage)
        {
            case 0:
                _sprout.SetActive(true);
                break;
            case 1:
                _sprout.SetActive(false);
                _bush.SetActive(true);
                break;
        }

        GrowStage++;
    }

    public virtual void ProgressDay()
    {
        if (_fertilized)
        {
            Grow();
            _fertilized = false;
            _planter.SetFertilizedMaterial(_fertilized);
        }

        if (GrowStage == 2)
        {
            if (_planter.WeedCount >= _weedThreshold)
            {
                _bush.SetActive(false);
                _deadBush.SetActive(true);
            }
            SpawnAilments();
        }

        _daysSinceLastWeed++;
    }

    void SpawnAilments()
    {
        if (_daysSinceLastWeed >= 2)
        {
            SpawnWeeds();
        }
        SpawnInsects();
    }

    void SpawnWeeds()
    {
        for (int i = 0; i < _maxWeedsPerDay; i++)
        {
            if (Random.Range(0.0f, 1.0f) <= _chanceToSpawnWeed)
            {
                float x = Random.Range(transform.position.x - 0.75f, transform.position.x + 0.75f);
                float z = Random.Range(transform.position.z - 0.75f, transform.position.z + 0.75f);
                Instantiate(_weedPrefab, new Vector3(x, transform.position.y, z), Quaternion.identity).AffectedPlant = this;
                _planter.WeedCount++;
                _daysSinceLastWeed = 0;
            }
        }
    }

    public void PullWeed()
    {
        _planter.WeedCount--;
    }

    void SpawnInsects()
    {
        //
    }
}
