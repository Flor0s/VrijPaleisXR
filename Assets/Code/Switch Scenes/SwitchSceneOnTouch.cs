using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchSceneOnTouch : MonoBehaviour
{
    public UnityEvent SwitchScene;

    private void OnTriggerEnter(Collider Player)
    {
        SwitchScene.Invoke();
    }
}