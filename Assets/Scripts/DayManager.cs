using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class DayManager : MonoBehaviour
{
    [SerializeField] UnityEvent OnDayChanged;

    public static event Action DayChanged;

    public void ProgressDay()
    {
        DayChanged?.Invoke();
        OnDayChanged?.Invoke();
    }
}
