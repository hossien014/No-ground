using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class SerializableVector3
{
      [JsonRequired]
      public float x, y, z;
      public Vector3 ToVector()
      {
            return new Vector3(x, y, z);
      }
}