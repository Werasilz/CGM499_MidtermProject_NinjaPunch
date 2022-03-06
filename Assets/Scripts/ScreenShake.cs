using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenShake : Singleton<ScreenShake>
{
    public CinemachineImpulseSource cinemachineImpulseSource;

    public void Shake(float multiplier)
    {
        Debug.Log("TEST");
        cinemachineImpulseSource.GenerateImpulse(Vector3.right * multiplier);
    }
}
