using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(MonoBehaviour),true)]
public class myCustumEditor : Editor
{
// بسم الله الرحمن الرحیم را به اینسپکتور اضافه می کند
      public override void OnInspectorGUI()
      {
         GUILayout.Box((Resources.Load("bes")as Texture));
            base.OnInspectorGUI();
            
      }

}
