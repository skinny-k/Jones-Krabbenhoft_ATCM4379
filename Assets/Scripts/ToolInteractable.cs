using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToolInteractable : MonoBehaviour
{
    [SerializeField] string _toolNeededToInteract;
    public string Tool => _toolNeededToInteract;
    
    public UnityEvent Activate;
}
