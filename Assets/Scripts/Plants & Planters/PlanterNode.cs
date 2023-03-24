using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlanterNode : ToolInteractable
{
    [SerializeField] Mesh _coveredMesh;
    [SerializeField] Material _regularMaterial;
    [SerializeField] Material _fertilizedMaterial;
    [SerializeField] ActivateSelectedInteractables _activatedItems;
    [SerializeField] UnityEvent DigUp;

    Plant _plant = null;
    public int WeedCount = 0;
    
    public override void UseTool()
    {
        if (_plant == null)
        {
            Activate?.Invoke();
        }
        else if (_plant.GrowStage > 0)
        {
            Debug.Log(_plant.GrowStage);
            Destroy(_plant.gameObject);
            _plant = null;
            SetFertilizedMaterial(false);
            DigUp?.Invoke();
        }
    }

    public void SetPlant(Plant newPlant)
    {
        if (_plant != null)
        {
            Destroy(_plant.gameObject);
        }

        _plant = newPlant;
    }

    /*
    public void RemovePlant()
    {
        if (_plant != null && _plant.GrowStage != 0)
        {
            Debug.Log(_plant.GrowStage);
            Destroy(_plant.gameObject);
            _plant = null;
        }
    }
    */

    public void SetFertilizedMaterial(bool state)
    {
        if (state)
        {
            GetComponent<MeshRenderer>().material = _fertilizedMaterial;
        }
        else
        {
            GetComponent<MeshRenderer>().material = _regularMaterial;
        }
    }

    public void QueryDeactivateSocket()
    {
        if (_activatedItems.Count > 0 && GetComponent<MeshFilter>().sharedMesh == _coveredMesh)
        {
            _activatedItems.UseOnAllSelected();
        }

        _activatedItems.GetComponent<ToggleSocket>().Toggle();
    }
}
