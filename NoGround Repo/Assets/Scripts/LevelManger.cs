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
      [SerializeField] Vector2Int CurrentLevel_key;

      [SerializeField] Dictionary<Vector2Int, Level> All_Levels_prefabs;
      Dictionary<Vector2Int, Level> Active_Levels;
      #region Deboging
      string d1 = "";
      string d2 = "";
      string d3 = "";
      #endregion
      private void Awake()
      {
            Active_Levels = new Dictionary<Vector2Int, Level>();
            player = FindObjectOfType<Player>();
            All_Levels_prefabs = GetAll_Levels_ForemResources();

      }
      private void Start()
      {
            Updat_Scene_Levels();
      }

      private void Update()
      {
            if (GetCurrentLevel_Key() != CurrentLevel_key)
            {
                  Updat_Scene_Levels();
                  CurrentLevel_key = GetCurrentLevel_Key();
                  print("as");

            }
      }
      Vector2Int GetCurrentLevel_Key()
      {
            var levels_Scale = new Vector3(160, 100, 0);
            var step1 = player.transform.position - transform.position;
            var CurrentLevelPos = new Vector2Int(Mathf.RoundToInt(step1.x / levels_Scale.x), Mathf.RoundToInt(step1.y / levels_Scale.y));
            d1 = CurrentLevelPos.ToString();

            return CurrentLevelPos;

      }
      public void Updat_Scene_Levels()
      {
            if (Active_Levels.Count == 0) Active_Levels = GetActiceLevels_dict();

            SetCurrentLevle();
            var NewActiveLevels = MakeNewActiveLevel_dic();
            var SpawnList = Spawn_New_Levels(NewActiveLevels);
            Remove_OutOfRang_levels(NewActiveLevels);
            Active_Levels = NewActiveLevels;
      }
      private Dictionary<Vector2Int, Level> GetActiceLevels_dict() => FindObjectsOfType<Level>().ToDictionary(x => x.Key);
      private void SetCurrentLevle() => CurrentLevel = Active_Levels[GetCurrentLevel_Key()];
      private Dictionary<Vector2Int, Level> MakeNewActiveLevel_dic()
      {
            Dictionary<Vector2Int, Level> NewActiveList = new Dictionary<Vector2Int, Level>();
            var Dirctions = _Utils.DirctionArray8_vector2();
            foreach (var Dirction in Dirctions)
            {
                  Level lvl;
                  if (All_Levels_prefabs.TryGetValue(Dirction + CurrentLevel.Key, out lvl))
                  {
                        
                        NewActiveList.Add(lvl.Key, lvl);
                  }
            }
            NewActiveList.Add(CurrentLevel.Key, CurrentLevel);
            return NewActiveList;
      }
      private List<Level> Spawn_New_Levels(Dictionary<Vector2Int, Level> NewActiveLevels)
      {
            List<Level> SpawnList = new List<Level>();
            foreach (var lvl in NewActiveLevels)
            {
                  if (!Active_Levels.ContainsKey(lvl.Key))
                  {
                        SpawnList.Add(lvl.Value);
                        All_Levels_prefabs.TryGetValue(lvl.Key, out Level Level_ToSpawn);
                        var pos = new Vector3(Level_ToSpawn.Key.x, Level_ToSpawn.Key.y, 0);
                        Instantiate(Level_ToSpawn, transform, false);
                  }
            }
            return SpawnList;
      }
      private void Remove_OutOfRang_levels(Dictionary<Vector2Int, Level> NewActiveLevels_dict)
      {
            foreach (var Level in Active_Levels)
            {
                  if (NewActiveLevels_dict.ContainsKey(Level.Key)) continue;
                  Destroy(Level.Value.gameObject);
            }
      }
      private Dictionary<Vector2Int, Level> GetAll_Levels_ForemResources()
      {
            var Level_OBjs = Resources.LoadAll("LevelPrefab");
            Dictionary<Vector2Int, Level> AllPrefabLevels_Dict = new Dictionary<Vector2Int, Level>();
            foreach (var Level_obj in Level_OBjs)
            {
                  var level = (Level_obj as GameObject).GetComponent<Level>();
                  AllPrefabLevels_Dict.Add(level.Key, level);
            }
            return AllPrefabLevels_Dict;
      }
      private string GetPath(string name) => Path.Combine(Application.persistentDataPath, name + ".txt");
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
