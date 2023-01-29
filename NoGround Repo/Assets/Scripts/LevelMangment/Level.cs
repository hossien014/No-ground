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
      [SerializeField] Player player;
      [SerializeField] public Vector2Int Key;
      // [SerializeField] public SerializableVector2 sLvlName;
      [SerializeField] public Transform StartNode;
      private void Update()
      {
            if (!Application.isPlaying)
            {
#if UNITY_EDITOR
                  SerializedObject serializedObj = new SerializedObject(this);
                  var S_property = serializedObj.FindProperty("Key");
                  name = $"lvl_{transform.localPosition.x}/{transform.localPosition.y}";
                  Key = new Vector2Int(Mathf.RoundToInt(transform.localPosition.x), Mathf.RoundToInt(transform.localPosition.y));
                  S_property.vector2IntValue = Key;
                  serializedObj.ApplyModifiedProperties();
                  transform.localPosition = transform.localPosition.RoundVector();
#endif

            }

      }
      private void OnDrawGizmos()
      {
            // Gizmos.color = Color.cyan;
            // var localPonit = new Vector3(16, -4.6f);
            // var scale = StartNode.localScale;
            // var Mpos = StartNode.transform.position;

            // var world1 = new Vector3(localPonit.x * scale.x + Mpos.x, localPonit.y * scale.y + Mpos.y);
            // var bpos = _Utils.GetWorldPoint(StartNode.transform, localPonit);
            // Gizmos.DrawSphere(bpos, 2);
            // print(GetWorldPoint(StartNode.transform, localPonit));
      }
}
