using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JsonHelper
{
    public static T FromJson<T>(string json)
    {
        return JsonUtility.FromJson<T>(json);
    }

    public static string ToJson(TargetJoint2D data)
    {
        return JsonUtility.ToJson(data);
    }
}
