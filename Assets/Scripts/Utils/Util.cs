using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    #region ReadJson
    public static T LoadJson<T>(string path)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(path);
        return JsonUtility.FromJson<T>(textAsset.text);
    }

    public static T LoadJsonList<T>(string path)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(path);
        return JsonConvert.DeserializeObject<T>(textAsset.text);
    }

    public static Dictionary<T, T2> LoadJsonDict<T, T2>(string path)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(path);
        return JsonConvert.DeserializeObject<Dictionary<T, T2>>(textAsset.text);
    }
    #endregion

    #region
    public static void WriteJson<T>(string path, T info)
    {

    }
    #endregion
}
