using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchSceneOnTouch : MonoBehaviour
{
    public string message;
    private float _articleTouched = 0f;

    private void OnCollisionEnter(Collision Player)
    {
        gameObject.SendMessage(message);
        Debug.Log(message);
    }
}