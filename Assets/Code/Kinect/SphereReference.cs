using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereReference : MonoBehaviour
{
    [SerializeField] GameObject trackedSphereReference;
    GameObject sphere;

    void Start()
    {
        sphere = Instantiate(trackedSphereReference);
        sphere.GetComponent<TrackedSphere>().transformReference = transform;
    }

    private void OnDestroy()
    {
        if (sphere)
        {
            Destroy(sphere);
        }
    }
}
