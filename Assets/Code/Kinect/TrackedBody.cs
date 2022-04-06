using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackedBody : MonoBehaviour
{
    [SerializeField] GameObject trackedSphereReference;
    GameObject sphereObj;
    TrackedSphere trackedSphere;
    float timePassed;

    void Start()
    {
        sphereObj = Instantiate(trackedSphereReference);
        trackedSphere = sphereObj.GetComponent<TrackedSphere>();
        trackedSphere.transformReference = transform;
    }

    private void Update()
    {
        CheckIfSphereBlocked();
    }

    void CheckIfSphereBlocked()
    {
        if (!trackedSphere.sphereGettingBlocked)
        {
            return;
        }

        timePassed += Time.deltaTime;
        if (timePassed >= .1f)
        {
            trackedSphere.bodyGettingBlocked = trackedSphere.CheckForBlockage(transform.position);
        }
    }

    private void OnDestroy()
    {
        if (sphereObj)
        {
            trackedSphere.StartCoroutine(trackedSphere.DelayDestroy());
        }
    }
}
