using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlanterNode : ToolInteractable
{
    [SerializeField] Mesh _coveredMesh;
    [SerializeField] ActivateSelectedInteractables _activatedItems;
    [SerializeField] UnityEvent DigUp;

    Plant _plant = null;
    
    public override void UseTool()
    {
        if (_plant == null)
        {
            Activate?.Invoke();
        }
        else
        {
            Destroy(_plant.gameObject);
            _plant = null;
            DigUp?.Invoke();
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
