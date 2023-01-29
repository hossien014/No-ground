using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Hand))]
public class HandInspactor : Editor
{
      public override void OnInspectorGUI()
      {
            base.OnInspectorGUI();
            Hand hand = (Hand)target;
            GUIContent gc = new GUIContent("Update");
            var s = new GUIStyle();
            s.fontSize = 22;
            GUI.skin.button.fontSize=14;
            GUI.skin.label.fontStyle=FontStyle.Normal;
            GUI.skin.button.fontStyle = FontStyle.Bold;
            if (GUILayout.Button(gc, GUILayout.Height(50)))
            {
                  hand.UpdateBodyPartSetting();
            }

      }
}