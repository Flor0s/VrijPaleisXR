using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Trigger : MonoBehaviour
{

    private int scalingFramesUpLeft = 0;
    private int scalingFramesDownLeft = 0;
    private Vector3 minScale;
    private Vector3 maxScale;

    public VideoPlayer movie;

    private void Start()
    {
        minScale = transform.localScale;
        maxScale = transform.localScale * 2f;
    }

    void Update()
    {
        if (scalingFramesUpLeft > 0)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, maxScale, Time.deltaTime * 10);
            scalingFramesUpLeft--;
        }

        else if (scalingFramesDownLeft > 0)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, minScale, Time.deltaTime * 10);
            scalingFramesDownLeft--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        scalingFramesUpLeft = 60;
        StartCoroutine(ScaleDown());

        movie.SetDirectAudioMute(0, false);
    }

    IEnumerator ScaleDown()
    {
        yield return new WaitForSeconds(10);
        scalingFramesDownLeft = 60;

        movie.SetDirectAudioMute(0, true);
    }
}
