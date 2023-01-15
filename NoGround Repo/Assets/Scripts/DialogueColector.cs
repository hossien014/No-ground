using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
[ExecuteAlways]

public enum D_Language { En, Fa };
public class DialogueColector : MonoBehaviour
{
      D_Language language = D_Language.Fa;
      [SerializeField] List<string> List_Fa = new List<string>();
      [SerializeField] List<string> List_En = new List<string>();


      public List<string> Get_Dialogue(D_Language _language)
      {
            if (language == D_Language.Fa) return List_Fa;
            if (language == D_Language.En) return List_En;
            else return null;

      }
      public List<string> Get_Fa_Dialogue()
      {
            return List_Fa;
      }

      public List<string> Get_EN_Dialogue()
      {
            return List_En;
      }

      public Dictionary<D_Language, List<string>> Get_Dialogue_Dictionery()
      {
            Dictionary<D_Language, List<string>> Dialogue_dic = new Dictionary<D_Language, List<string>>();
            Dialogue_dic.Add(D_Language.Fa, List_Fa);
            Dialogue_dic.Add(D_Language.En, List_En);
            return Dialogue_dic;
      }

      public string GetPath(string name)
      {
            return Path.Combine(Application.persistentDataPath, name + ".txt");
      }

      public void SaveDialogues(string name)
      {
            var m_Path = GetPath(name);
            string Dict_Json = JsonConvert.SerializeObject(Get_Dialogue_Dictionery());
            using (TextWriter Tw = File.CreateText(m_Path))
            {
                  Tw.WriteLine(Dict_Json);
            }
            Debug.Log($"Dialogues saved in {m_Path}");
      }

      public void LoadDialogues(string name)
      {
            var m_Path = GetPath(name);
            Debug.Log($"Dialogues  in {m_Path}");
            var Json = File.ReadAllText(m_Path);
            var Dict_Json = JsonConvert.DeserializeObject<Dictionary < D_Language, List< string >>>(Json);

            List_En =Dict_Json[D_Language.En];
            List_Fa =Dict_Json[D_Language.Fa];
      }


}
