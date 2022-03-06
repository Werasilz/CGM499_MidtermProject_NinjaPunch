using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action RestartEvent;
    public static event Action HPFullEvent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartEvent?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            HPFullEvent?.Invoke();
        }
    }
}
