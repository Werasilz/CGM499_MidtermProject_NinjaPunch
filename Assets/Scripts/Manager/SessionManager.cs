using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : Singleton<SessionManager>
{
    private DateTime _sessionStartTime;
    private DateTime _sessionEndTime;

    private void Start()
    {
        _sessionStartTime = DateTime.Now;
        Debug.Log("Game session start : " + _sessionStartTime);
    }

    private void OnApplicationQuit()
    {
        _sessionEndTime = DateTime.Now;
        TimeSpan timeDifference = _sessionEndTime.Subtract(_sessionStartTime);
        Debug.Log("Game session ended : " + _sessionEndTime);
        Debug.Log("Game session lasted : " + timeDifference);
    }
}
