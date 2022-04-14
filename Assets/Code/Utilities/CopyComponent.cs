using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CopyComponent 
{
    public static T Copy<T>(T original, GameObject destination) where T : Component
    {
       System.Type type = original.GetType();
       Component copy = destination.AddComponent(type);
       System.Reflection.FieldInfo[] fields = type.GetFields();
       foreach (var field in fields)
       {
           field.SetValue(copy, field.GetValue(original));
       }

       return copy as T;
    }
}
