using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPunchSounds : MonoBehaviour
{
    [SerializeField] FMODUnity.StudioEventEmitter emitter;
    public void PunchSound()
    {
        emitter.Play();
        emitter.SetParameter("WaterPunch", 1);
    }

    public void WaterSound()
    {
        emitter.Play();
        emitter.SetParameter("WaterPunch", 0);
    }
}
