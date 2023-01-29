using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Abed.Utils;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public enum Tag { Player, LevelManger };

public class savingSystem : MonoBehaviour
{
      private void Update()
      {
            d.ok(() => { save("noGroundSave"); });
            d.ik(() => { Load("noGroundSave"); });
      }
      public void save(string filename)
      {
            Dictionary<Tag, object> DATA_Dict = MakeDataDictionary();
            string path = GetPath(filename);
            SerializedData_Binary(DATA_Dict, path);
      }

      private void SerializedData_Binary(Dictionary<Tag, object> DATA_Dict, string path)
      {
            using (FileStream filestream = File.Open(path, FileMode.Create))
            {
                  BinaryFormatter bf = new BinaryFormatter();
                  bf.Serialize(filestream, DATA_Dict);
                  d.w(path + "saved");
            }
      }
      private Dictionary<Tag, object> MakeDataDictionary()
      {
            //make data Dictionary 
            var DATA_Dict = new Dictionary<Tag, object>();
            var savebleEntitys = FindObjectsOfType<SavebleEntity>();
            foreach (var saveble in savebleEntitys)
            {
                  saveble.CaptureState(out object obj, out Tag tag);
                  DATA_Dict.Add(tag, obj);
            }
            return DATA_Dict;
      }

      public void Load(string filename)
      {
            var path = GetPath(filename);

            path = GetPath(filename);
            using (FileStream fs = File.Open(path, FileMode.Open))
            {
                  BinaryFormatter bf = new BinaryFormatter();
                  var data = bf.Deserialize(fs) as Dictionary<Tag, object>;
                  foreach (var saveble in FindObjectsOfType<SavebleEntity>())
                  {
                        var id = saveble.GetTag();
                        if (data.ContainsKey(id))
                        {
                              saveble.RestoreState(data[id]);
                        }
                  }
            }
            d.w(path + "Loaded");
      }

      private string GetPath(string filename) => Path.Combine(Application.persistentDataPath, filename + ".txt");





}