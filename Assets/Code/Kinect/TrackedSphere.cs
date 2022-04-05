using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackedSphere : MonoBehaviour
{
    public GameObject[] spheres;

    [SerializeField] LayerMask sphereLayer;
    Transform kinectTransform;

    public Transform transformReference;
    [SerializeField] float distanceThreshold = 5f;
    [SerializeField] float destroyDelayTime = 1f;

    [SerializeField] float maxRejoinDistance = 10f;
    public bool gettingBlocked;
    float timePassed;

    bool gettingDestroyed;
    float distance;
    float previousDistance;

    void Start()
    {
        transform.position = transformReference.position;
        kinectTransform = GameObject.FindGameObjectWithTag("KinectTransform").transform;

        if (transformReference)
        {
            CheckBlockedSpheres();
        }
    }

    void CheckBlockedSpheres()
    {
        spheres = GameObject.FindGameObjectsWithTag("Sphere");
        foreach(GameObject sphere in spheres)
        {
            if (sphere.GetComponent<TrackedSphere>().transformReference)
            {
                return;
            }

            Destroy(sphere);
        }
    }

    void Update()
    {
        CheckForBlockage();
    }

    void CheckForBlockage()
    {
        timePassed += Time.deltaTime;
        if(timePassed < 1f)
        {
            return;
        }

        gettingBlocked = Physics.Linecast(transform.position, kinectTransform.position, sphereLayer);

        timePassed = 0f;
    }

    void LateUpdate()
    {
        if (gettingDestroyed || gettingBlocked)
        {
            return;
        }

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
            StartCoroutine(DestroyDelay());
        }
    }

    void MoveToReference()
    {
        if(distance - previousDistance <= .05f && distance - previousDistance > -.05f)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, transformReference.position, .5f);
    }

    public IEnumerator DestroyDelay()
    {
        gettingDestroyed = true;

        yield return new WaitForSeconds(destroyDelayTime);

        if (!gettingBlocked)
        {
            Destroy(gameObject);
        }
    }
}
