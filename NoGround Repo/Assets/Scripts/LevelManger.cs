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
      Vector2Int CurrentLevel_key;

      [SerializeField] Dictionary<Vector2Int, Level> All_Levels_prefabs;
      Dictionary<Vector2Int, Level> Active_Levels;
      #region Deboging
      [SerializeField] List<Level> L1 = new List<Level>();
      string d1 = "";
      string d2 = "";
      string d3 = "";
      #endregion
      private void Awake()
      {
            Active_Levels = new Dictionary<Vector2Int, Level>();
            player = FindObjectOfType<Player>();
            All_Levels_prefabs = GetAll_Levels_ForemResources();
            if (Active_Levels.Count == 0) Active_Levels = GetActiceLevels_dict();

      }
      private void Start()
      {
            Updat_Scene();
      }

      private void Update()
      {
            if (GetCurrentLevel_Key() != CurrentLevel_key)
            {
                  Updat_Scene();
                  CurrentLevel_key = GetCurrentLevel_Key();

            }
      }
      private void Updat_Scene()
      {
            SetCurrentLevle();
            Dictionary<Vector2Int, Level> NewActiveList = new Dictionary<Vector2Int, Level>();
            var Dirctions = _Utils.DirctionArray8_vector2();
            Dictionary<Vector2Int, Level> NewActive_Levels_List = new Dictionary<Vector2Int, Level>();
            NewActive_Levels_List.Add(CurrentLevel.Key, CurrentLevel);
            RemoveOldAndSpawnNewLevels(Dirctions, NewActive_Levels_List);
      }

      private void RemoveOldAndSpawnNewLevels(Vector2Int[] Dirctions, Dictionary<Vector2Int, Level> NewActive_Levels_List)
      {
            foreach (var Dirction in Dirctions)
            {
                  Level lvl;
                  var tmptKey = Dirction + CurrentLevel.Key;
                  if (All_Levels_prefabs.TryGetValue(tmptKey, out lvl))
                  {
                        if (Active_Levels.ContainsKey(tmptKey))
                        {
                              NewActive_Levels_List.Add(tmptKey, Active_Levels[tmptKey]);
                        }
                        else
                        {
                              var newLevel = Instantiate(lvl, transform, false);
                              Active_Levels.Add(newLevel.Key, newLevel);
                              NewActive_Levels_List.Add(newLevel.Key, newLevel);
                        }

                  }
            }
            foreach (var item in Active_Levels)
            {
                  if (NewActive_Levels_List.ContainsKey(item.Key)) continue;
                  Destroy(item.Value.gameObject);
            }
            Active_Levels = NewActive_Levels_List;
      }

      Vector2Int GetCurrentLevel_Key()
      {
            var levels_Scale = new Vector3(160, 100, 0);
            var step1 = player.transform.position - transform.position;
            var CurrentLevelPos = new Vector2Int(Mathf.RoundToInt(step1.x / levels_Scale.x), Mathf.RoundToInt(step1.y / levels_Scale.y));
            d1 = CurrentLevelPos.ToString();

            return CurrentLevelPos;

      }

      private Dictionary<Vector2Int, Level> GetActiceLevels_dict() => FindObjectsOfType<Level>().ToDictionary(x => x.Key);
      private void SetCurrentLevle() => CurrentLevel = (Active_Levels.ContainsKey(GetCurrentLevel_Key())) ? Active_Levels[GetCurrentLevel_Key()] : CurrentLevel;


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
