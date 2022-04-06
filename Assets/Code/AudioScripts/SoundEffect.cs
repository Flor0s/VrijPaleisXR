using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Oculus.Platform.Samples.VrHoops;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

[Serializable]
public class SoundEffects
{
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private AudioSource[] sources;

    [Range(15f, 50f)] [SerializeField] private float frequency;
    [Range(0.0f, 10f)] [SerializeField] private float deviation;
    [SerializeField] private bool randomRepeat = false;
    

    public IEnumerator Play()
    {
        yield return new WaitForSeconds(ReturnDelay());
        
    }
    
    public void PlayEffect()
    {
        var i = Random.Range(0, sources.Length - 1);
        sources[i].clip = clips[Random.Range(0, clips.Length - 1)];
        sources[i].Play();
        Debug.Log($"Sound playing from {i}");
    }

    public float ReturnDelay()
    {
        return Random.Range(frequency - deviation, frequency + deviation);
    }
}
