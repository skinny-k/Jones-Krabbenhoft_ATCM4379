using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRBaseInteractor))]
public class ActivateSelectedInteractables : MonoBehaviour
{
    [SerializeField] UnityEvent OnActivate;

    public int Count { get => GetComponent<XRBaseInteractor>().interactablesSelected.Count; }
    
    public void UseOnAllSelected()
    {
        Debug.Log("In ActivateSelectedInteractables.UseOnAllSelected()");

        if (GetComponent<XRBaseInteractor>().interactablesSelected.Count != 0)
        {
            foreach (IXRSelectInteractable interactable in GetComponent<XRBaseInteractor>().interactablesSelected)
            {
                interactable.transform?.GetComponent<ActivatedItem>().Activate();
            }

            OnActivate?.Invoke();
        }
    }

    public void UseOnIndex(int index)
    {
        if (GetComponent<XRBaseInteractor>().interactablesSelected.Count != 0 && index >= 0 && index < GetComponent<XRBaseInteractor>().interactablesSelected.Count)
        {
            GetComponent<XRBaseInteractor>().interactablesSelected[index].transform?.GetComponent<ActivatedItem>().Activate();

            OnActivate?.Invoke();
        }
    }

    public void UseOnSpecific(IXRSelectInteractable interactable)
    {
        if (GetComponent<XRBaseInteractor>().interactablesSelected.Count != 0)
        {
            List<IXRSelectInteractable> interactablesSelected = GetComponent<XRBaseInteractor>().interactablesSelected;

            if (interactablesSelected.Contains(interactable))
            {
                interactable.transform?.GetComponent<ActivatedItem>().Activate();
            }

            OnActivate?.Invoke();
        }
    }
}
