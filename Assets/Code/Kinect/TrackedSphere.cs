using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackedSphere : MonoBehaviour
{
    [HideInInspector] public Transform transformReference;
    [SerializeField] float distanceThreshold;

    float distance;
    float previousDistance;

    void Start()
    {
        transform.position = transformReference.position;
    }

    void LateUpdate()
    { 
        if (transform.position != new Vector3(0, 0, 0))
        {
            CheckDistance();
        }

        MoveToReference();
    }

    void CheckDistance()
    {
        previousDistance = distance;
        distance = Vector3.Distance(transform.position, transformReference.position);

        if(distance > distanceThreshold)
        {
            Destroy(gameObject);
        }
    }

    void MoveToReference()
    {
        if(distance - previousDistance <= .05f && distance - previousDistance > -.05f)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, transformReference.position, .3f);
    }
}
