using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using Abed.Utils;

public class LevelManger : MonoBehaviour
{
      [SerializeField] Player player;
      [SerializeField] Level CurrentLevel;
      [SerializeField] Dictionary<Vector2Int, Level> AllLevels;
      Dictionary<Vector2Int, Level> Active_Levels;


      #region Deboging
      string d1 = "";
      string d2 = "";
      string d3 = "";
      #endregion

      private void Start()
      {
            player = FindObjectOfType<Player>();
            Active_Levels = new Dictionary<Vector2Int, Level>();
            //  CurrentLevel = new Vector2Int(1, 1);
            AllLevels = GetAll_Levels_ForemResources();
            UpdatelevelManger();
      }

      private void Update()
      {
            GetCurrentLevel_Key();
      }
      Vector2Int GetCurrentLevel_Key()
      {
            var levels_Scale = new Vector3(160, 100, 0);
            var step1 = player.transform.position - transform.position;
            var CurrentLevelPos = new Vector2Int(Mathf.RoundToInt(step1.x / levels_Scale.x), Mathf.RoundToInt(step1.y / levels_Scale.y));
            d1 = CurrentLevelPos.ToString();
            return CurrentLevelPos;

      }
      public void UpdatelevelManger()
      {
            if (Active_Levels.Count == 0) Active_Levels = GetActiceLevels_dic();
            SetCurrentLevle();
            var NewActiveLevels = MakeNewActiveLevel_dic();
            var SpawnList = MakeSpawnList(NewActiveLevels);
            RemoveOutOfrang_levels(NewActiveLevels);
            Active_Levels = NewActiveLevels;

            // SpawnLevel();
      }

      private void RemoveOutOfrang_levels(Dictionary<Vector2Int, Level> newActiveLevels)
      {
            foreach (var lvl in Active_Levels)
            {
                  if (newActiveLevels.ContainsKey(lvl.Key)) continue;
                  Destroy(lvl.Value.gameObject);
            }
      }
      private List<Level> MakeSpawnList(Dictionary<Vector2Int, Level> NewActiveLevels)
      {
            List<Level> SpawnList = new List<Level>();
            foreach (var lvl in NewActiveLevels)
            {
                  if (!Active_Levels.ContainsKey(lvl.Key))
                  {
                        SpawnList.Add(lvl.Value);
                        AllLevels.TryGetValue(lvl.Key, out Level sl);
                        var pos = new Vector3(sl.Key.x, sl.Key.y, 0);
                        var aaa = Instantiate(sl, transform, false);
                        print("a");
                  }
            }

            return SpawnList;
      }

      private Dictionary<Vector2Int, Level> GetActiceLevels_dic()
      {
            var leles = FindObjectsOfType<Level>();
            Dictionary<Vector2Int, Level> newdic = new Dictionary<Vector2Int, Level>();
            foreach (var item in leles)
            {
                  newdic.Add(item.Key, item); Debug.DebugBreak();
            }

            return newdic;
      }
      private Dictionary<Vector2Int, Level> MakeNewActiveLevel_dic()
      {
            Dictionary<Vector2Int, Level> NewActiveList = new Dictionary<Vector2Int, Level>();
            var Dirctions = _Utils.DirctionArray8_vector2();
            foreach (var Dirction in Dirctions)
            {
                  Level lvl;
                  if (AllLevels.TryGetValue(Dirction + CurrentLevel.Key, out lvl))
                  {
                        NewActiveList.Add(lvl.Key, lvl);
                  }
            }
            NewActiveList.Add(CurrentLevel.Key, CurrentLevel);
            return NewActiveList;
      }

      private void SetCurrentLevle()
      {
            CurrentLevel = Active_Levels[GetCurrentLevel_Key()];
      }
      private string GetPath(string name)
      {
            return Path.Combine(Application.persistentDataPath, name + ".txt");
      }
      private Dictionary<Vector2Int, Level> GetAll_Levels_ForemResources()
      {
            var Level_OBjs = Resources.LoadAll("LevelPrefab");
            Dictionary<Vector2Int, Level> AllPrefabLevels_Dict = new Dictionary<Vector2Int, Level>();
            foreach (var Level_obj in Level_OBjs)
            {
                //  var _Level_Obj = (Level_obj as GameObject).GetComponent<Level>();
                 // var level = _Level_Obj.GetComponent<Level>();
                  var level= (Level_obj as GameObject).GetComponent<Level>();
                  AllPrefabLevels_Dict.Add(level.Key, level);
            }
            AllLevels = AllPrefabLevels_Dict;
            return AllPrefabLevels_Dict;
      }


      private void OnGUI()
      {
            GUILayout.BeginHorizontal();
            var size = GUI.skin.box.CalcSize(new GUIContent(d1));
            GUILayout.Box(d1, GUILayout.Width(size.x + 5), GUILayout.Height(size.y + 5));

            var size2 = GUI.skin.box.CalcSize(new GUIContent(d2));
            GUILayout.Box(d2, GUILayout.Width(size2.x + 5), GUILayout.Height(size2.y + 5));

            var size3 = GUI.skin.box.CalcSize(new GUIContent(d3));
            GUILayout.Box(d3, GUILayout.Width(size3.x + 5), GUILayout.Height(size3.y + 5));

            GUILayout.EndHorizontal();
      }

}
