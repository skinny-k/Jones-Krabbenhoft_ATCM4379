using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    [SerializeField] string _toolName;
    [SerializeField] LayerMask _interactionMask;

    List<ToolInteractable> _collidingWith = new List<ToolInteractable>();

    void OnTriggerEnter(Collider other)
    {
        ToolInteractable interactable = other.gameObject.GetComponent<ToolInteractable>();
        if ((_interactionMask & 1 << other.gameObject.layer) != 0 && interactable != null && interactable.Tool == _toolName)
        {
            _collidingWith.Add(interactable);
        }
    }

    void OnTriggerExit(Collider other)
    {
        ToolInteractable interactable = other.gameObject.GetComponent<ToolInteractable>();
        if ((_interactionMask & 1 << other.gameObject.layer) != 0 && interactable != null && interactable.Tool == _toolName)
        {
            _collidingWith.Remove(interactable);
        }
    }

    public void Activate()
    {
        if (_collidingWith.Count > 0)
        {
            _collidingWith[_collidingWith.Count - 1].Activate?.Invoke();
        }
    }
}