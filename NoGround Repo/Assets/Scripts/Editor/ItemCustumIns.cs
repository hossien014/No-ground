using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Item))]
public class ItemCustumIns : Editor
{
      public override void OnInspectorGUI()
      {
            Item i = (Item)target;
            base.OnInspectorGUI();
            if (GUILayout.Button("UpdateSprite"))
            {
                  i.updateSprite();
            }

      }
}