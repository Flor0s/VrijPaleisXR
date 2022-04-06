using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    [SerializeField] private SoundEffects[] warSounds;
    [SerializeField] private SoundEffects[] oceanSounds;


    private void Awake()
    {
        CheckSetInstance();
        StartOcean();
    }

    private void StartOcean()
    {
        foreach (SoundEffects sounds in oceanSounds)
        {
            //Invoke(, sounds.ReturnDelay());
            print("Sound active");
        }
    }

    private void CheckSetInstance()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void Cheat(Func<float> function)
    {
        foreach (SoundEffects sounds in oceanSounds)
        {
                        
        }
    }
}
