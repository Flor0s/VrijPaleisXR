using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizedPlay : MonoBehaviour
{
    [SerializeField] private float playInterval;
    [SerializeField] private float deviation;

    [SerializeField] private SoundEffect effect;

    private float waitTime = 0;
    private bool shouldRepeat = true;
    private float f;

    private void OnEnable()
    {
        shouldRepeat = true;
    }

    private void OnDisable()
    {
        shouldRepeat = false;
        waitTime = Deviation.Deviate(1f,5f);
    }

    private void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            f = Deviation.Deviate(playInterval - this.deviation, playInterval + this.deviation);
            StartCoroutine(effect.Play(f));
            waitTime = f + effect.ReturnClipLength();
        }
    }
}
