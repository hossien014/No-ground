using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Abed.Utils;
using System;
using System.Xml.Serialization;
using UnityEditor;
[ExecuteAlways]
[SelectionBase]
[System.Serializable]
// 160 width  100  Hight is size of lvl
public class Level : MonoBehaviour
{
      [SerializeField] public Vector2Int Key;
      // [SerializeField] public SerializableVector2 sLvlName;


      private void Awake()
      {

      }
      private void Update()
      {
            if (!Application.isPlaying)
            {
                  SerializedObject serializedObj = new SerializedObject(this);
                  var S_property =serializedObj.FindProperty("Key");
                  name = $"lvl_{transform.localPosition.x}/{transform.localPosition.y}";
                  Key = new Vector2Int(Mathf.RoundToInt(transform.localPosition.x), Mathf.RoundToInt(transform.localPosition.y));
                  S_property.vector2IntValue=Key;
                  serializedObj.ApplyModifiedProperties();
                  transform.localPosition = transform.localPosition.RoundVector();

            }

      }
}
