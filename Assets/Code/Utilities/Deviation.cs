using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Deviation 
{
    public static int Deviate(int a, int b)
    {
        return Random.Range(a - b, a + b);
    }

    public static float Deviate(float a, float b)
    {
        return Random.Range(a - b, a + b);
    }
}
