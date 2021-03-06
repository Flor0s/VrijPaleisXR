using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsUpdate : MonoBehaviour
{
    [Header("UpdateWall")]
    public bool UpdateWall = false;

    [SerializeField] private Vector3 _StartPosWalls;

    [Header("Position")]
    [Tooltip("In this project only the Y is use full")]
    public Vector3 EndPosWalls;

    private float DelayTime = 1f;

    [Header("Statment To move wall")]
    public bool DoWallDown = false;

    public bool DoWallUp = false;
    public bool WallIsUp;

    private void Start()
    {
        _StartPosWalls = gameObject.transform.position;
        WallIsUp = true;
    }

    public void updateWallPosition()
    {
        _StartPosWalls = gameObject.transform.position;
        UpdateWall = false;
    }

    private void Update()
    {
        if (DoWallDown == true)
        {
            StartCoroutine(WallsGoingDown());
        }

        if (DoWallUp == true)
        {
            StartCoroutine(WallsGoingUp());
        }

        if (UpdateWall == true)
        {
            updateWallPosition();
        }
    }

    //  private void WallsGoingDown()
    // {
    //  }

    private IEnumerator WallsGoingDown()
    {
        float startTime = Time.time; // Time.time contains current frame time, so remember starting point
        while (Time.time - startTime <= DelayTime)
        {
            gameObject.transform.position = Vector3.Lerp(_StartPosWalls, EndPosWalls, Time.time - startTime);
            DoWallDown = false;
            yield return 1;
        }
        WallIsUp = false;
    }

    private IEnumerator WallsGoingUp()
    {
        float startTime = Time.time; // Time.time contains current frame time, so remember starting point
        while (Time.time - startTime <= DelayTime)
        {
            gameObject.transform.position = Vector3.Lerp(EndPosWalls, _StartPosWalls, Time.time - startTime);
            DoWallUp = false;

            yield return 1;
        }
        WallIsUp = true;
    }
}