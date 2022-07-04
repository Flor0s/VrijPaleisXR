using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchArticles : MonoBehaviour
{
    public GameObject Walls;

    public Material[] SkyBoxes;
    private WallsUpdate wallsUpdate;

    private float TimerTime = 30f;

    public UnityEvent UpdateSuroundingsWar;
    public UnityEvent UpdateSuroundingsOceaan;
    public UnityEvent UpdateSuroundingsAmazone;

    private void Start()
    {
        wallsUpdate = Walls.GetComponent<WallsUpdate>();
    }

    public void SwitchToWar()
    {
        StartCoroutine(SwitchingToWar());
    }

    private IEnumerator SwitchingToWar()
    {
        if (wallsUpdate.WallIsUp)
        {
            UpdateSuroundingsWar.Invoke();
            wallsUpdate.DoWallDown = true;
            RenderSettings.skybox = SkyBoxes[0];
        }
        else
        {
            wallsUpdate.DoWallUp = true;
            yield return new WaitForSeconds(1.3f);

            UpdateSuroundingsWar.Invoke();
            wallsUpdate.DoWallDown = true;
            RenderSettings.skybox = SkyBoxes[0];
        }

        yield return 1;
    }

    public void SwitchToOceaan()
    {
        StartCoroutine(SwitchingToOceaan());
    }

    private IEnumerator SwitchingToOceaan()
    {
        if (wallsUpdate.WallIsUp)
        {
            UpdateSuroundingsOceaan.Invoke();
            wallsUpdate.DoWallDown = true;
            RenderSettings.skybox = SkyBoxes[1];
        }
        else
        {
            wallsUpdate.DoWallUp = true;
            yield return new WaitForSeconds(1.3f);

            UpdateSuroundingsOceaan.Invoke();
            wallsUpdate.DoWallDown = true;
            RenderSettings.skybox = SkyBoxes[1];
        }

        yield return 1;
    }

    public void SwitchToAmazone()
    {
        StartCoroutine(SwitchingToAmazone());
    }

    private IEnumerator SwitchingToAmazone()
    {
        if (wallsUpdate.WallIsUp)
        {
            UpdateSuroundingsAmazone.Invoke();
            wallsUpdate.DoWallDown = true;
            RenderSettings.skybox = SkyBoxes[2];
        }
        else
        {
            wallsUpdate.DoWallUp = true;
            yield return new WaitForSeconds(1.3f);

            UpdateSuroundingsAmazone.Invoke();
            wallsUpdate.DoWallDown = true;
            RenderSettings.skybox = SkyBoxes[2];
        }

        yield return 1;
    }
}