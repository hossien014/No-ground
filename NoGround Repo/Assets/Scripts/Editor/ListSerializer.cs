
// using System;
// using UnityEditor;
// using UnityEngine;
// using System.Collections.Generic;
// using Newtonsoft.Json;
// using System.IO;

// public class ListSerializer : EditorWindow
// {
//       string Log_1 = " ";
//       [MenuItem("NoGround/ListSerializer")]

//       private static void ShowWindow()
//       {
//             var window = GetWindow<ListSerializer>();
//             window.titleContent = new GUIContent("ListSerializer");
//             window.Show();
//       }

//       private void OnGUI()
//       {
//             int llk = 0;
//             GUILayout.BeginHorizontal();
//             if (GUILayout.Button("MakeDictonery")) { prosses(); }
//             GUILayout.Box($"number of levels : {Log_1}");
//             GUILayout.EndHorizontal();




//       }

//       private void prosses()
//       {
//             var Dict = FindAllSceneInResorses();
//             SerializeDictoinery("Levels", Dict);

//       }

//       private void SerializeDictoinery(string Name, object levels)
//       {
//             var s = JsonConvert.SerializeObject(levels);
//             Debug.Log("sasa");

//       }

//       private string GetPath(string name)
//       {
//             return Path.Combine(Application.persistentDataPath, name + ".tex");
//       }

//       private Dictionary<SerializableVector2, Level> FindAllSceneInResorses()
//       {
//             var lvlObj = Resources.LoadAll("LevelPrefab");
//             Dictionary<SerializableVector2, Level> levelsDict = new Dictionary<SerializableVector2, Level>();
//             foreach (var item in lvlObj)
//             {
//                   var _Level_Obj = item as GameObject;
//                   var level = _Level_Obj.GetComponent<Level>();
//                   levelsDict.Add(level.sLvlName, level);
//             }
//             return levelsDict;
//       }


// }
