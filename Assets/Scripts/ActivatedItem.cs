using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivatedItem : MonoBehaviour
{
    [SerializeField] UnityEvent OnActivate;
    
    public virtual void Activate()
    {
        Debug.Log("In ActivatedItem.Activate()");
        
        OnActivate?.Invoke();
    }
}
