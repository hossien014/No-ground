using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelManger))]
public class CustomInspactor : Editor
{
      public override void OnInspectorGUI()
      {
            DrawDefaultInspector();
            LevelManger lm=(LevelManger)target;
          //  base.OnInspectorGUI();
          
         

      }
}