using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class DialogueTool : EditorWindow
{
      Vector2 scorllPos;
      Texture Header_Img ;

      [MenuItem("NoGround/DiolgoTool")]
      private static void ShowWindow()
      {
            var window = GetWindow<DialogueTool>();
            window.titleContent = new GUIContent("DiolgoTool");
            window.Show();
      }
      private void OnGUI()
      {
            Header_Img = Resources.Load("allhe")as Texture;
            GUIStyle Header_S = SetHeadrStyle();

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Save", GUILayout.Width(50), GUILayout.Height(50)))
            {
                  FindObjectOfType<DialogueColector>().SaveDialogues("Dialogue");
            }
            if (GUILayout.Button("Load", GUILayout.Width(50), GUILayout.Height(50)))
            {
                  FindObjectOfType<DialogueColector>().LoadDialogues("Dialogue");
            }
            GUILayout.Box(Header_Img);
            GUILayout.EndHorizontal();
            Dialogue_windos(Header_S);
      }

      private void Dialogue_windos(GUIStyle Header_S)
      {
            var Fa_Diolog = FindObjectOfType<DialogueColector>().Get_Fa_Dialogue();
            var En_Diolog = FindObjectOfType<DialogueColector>().Get_EN_Dialogue();
            ShowDialogue(Fa_Diolog, "farsi", 0, Header_S);
            ShowDialogue(En_Diolog, "En", 1, Header_S);
      }

      private static GUIStyle SetHeadrStyle()
      {
            GUIStyle Header_S = new GUIStyle();
            Header_S.normal.textColor = Color.magenta;
            Header_S.fontSize = 15;
            return Header_S;
      }

      private void ShowDialogue(List<string> m_Diolog, string lable, int index, GUIStyle Header_S)
      {
            int Di_count = m_Diolog.Count;
            GUILayout.BeginArea(new Rect(5 + (400 * index), 60, 400, 1000));
            GUILayout.Label($"{lable} ({Di_count})", Header_S);

            scorllPos = EditorGUILayout.BeginScrollView(scorllPos, false, true, GUILayout.Width(400), GUILayout.Height(400));
            for (int i = 0; i < Di_count; i++)
            {
                  EditorGUILayout.BeginHorizontal();
                  EditorGUILayout.IntField(i, GUILayout.Width(20));
                  m_Diolog[i] = EditorGUILayout.TextArea(m_Diolog[i], GUILayout.Height(50));
                  EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndScrollView();
            GUILayout.EndArea();
      }
}