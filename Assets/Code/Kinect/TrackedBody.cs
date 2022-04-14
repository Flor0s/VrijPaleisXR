using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackedBody : MonoBehaviour
{
    [SerializeField] GameObject trackedSpherePrefab;

    [SerializeField] float distanceThreshold = 1f;

    GameObject sphereObj;
    TrackedSphere trackedSphere;
    float timePassed;

    void Start()
    {
        Debug.Log("Setup tag for distance check");
        //Transform vrHeadset = GameObject.FindGameObjectWithTag("VrHeadset").transform;
        //if(Vector3.Distance(transform.position, vrHeadset.position) <= distanceThreshold)
        //{
        //    Destroy(gameObject);
        //}

        sphereObj = Instantiate(trackedSpherePrefab);
        trackedSphere = sphereObj.GetComponent<TrackedSphere>();
        trackedSphere.transformReference = transform;
    }

    public Vector3 GetMirroredPosition()
    {
        return new Vector3(-transform.position.x, transform.position.y, transform.position.z);
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
            trackedSphere.bodyGettingBlocked = trackedSphere.CheckForBlockage(GetMirroredPosition());
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
