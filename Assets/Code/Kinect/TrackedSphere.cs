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

    public bool sphereGettingBlocked;
    public bool bodyGettingBlocked;
    float timePassed;

    float distance;
    float previousDistance;

    void Start()
    {
        transform.position = transformReference.position;
        kinectTransform = GameObject.FindGameObjectWithTag("KinectTransform").transform;

        CheckBlockedSpheres();
    }

    void CheckBlockedSpheres()
    {
        spheres = GameObject.FindGameObjectsWithTag("Sphere");
        foreach(GameObject sphere in spheres)
        {
            if (!sphere.GetComponent<TrackedSphere>().transformReference)
            {
                float distance = Vector3.Distance(transform.position, sphere.transform.position);
                if(distance <= distanceThreshold)
                {
                    Destroy(sphere);
                }
            }
        }
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= .1f)
        {
            sphereGettingBlocked = CheckForBlockage(transform.position);
        }
    }

    public bool CheckForBlockage(Vector3 pos)
    {
        timePassed = 0f;

        return Physics.Linecast(pos, kinectTransform.position, sphereLayer);
    }

    void LateUpdate()
    {
        if (!transformReference || sphereGettingBlocked && bodyGettingBlocked)
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
            StartCoroutine(DelayDestroy());
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

    public IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(destroyDelayTime);

        if (!sphereGettingBlocked)
        {
            Destroy(gameObject);
        }
    }
}
