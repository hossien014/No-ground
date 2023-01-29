using UnityEngine;
namespace Abed.Utils
{


      public class GeneralGUI : MonoBehaviour
      {

            public string[] S = new string[6];

            private void OnGUI()
            {

                  GUILayout.BeginHorizontal();

                  if (!string.IsNullOrEmpty(S[0]))
                  {
                        var size = GUI.skin.box.CalcSize(new GUIContent(S[0]));
                        GUILayout.Box(S[0], GUILayout.Width(size.x + 5), GUILayout.Height(size.y + 5));
                  }
                  if (!string.IsNullOrEmpty(S[1]))
                  {
                        var size = GUI.skin.box.CalcSize(new GUIContent(S[1]));
                        GUILayout.Box(S[1], GUILayout.Width(size.x + 5), GUILayout.Height(size.y + 5));
                  }

                  if (!string.IsNullOrEmpty(S[2]))
                  {
                        var size = GUI.skin.box.CalcSize(new GUIContent(S[2]));
                        GUILayout.Box(S[2], GUILayout.Width(size.x + 5), GUILayout.Height(size.y + 5));
                  }

                  if (!string.IsNullOrEmpty(S[3]))
                  {
                        var size = GUI.skin.box.CalcSize(new GUIContent(S[3]));
                        GUILayout.Box(S[3], GUILayout.Width(size.x + 5), GUILayout.Height(size.y + 5));
                  }

                  if (!string.IsNullOrEmpty(S[4]))
                  {
                        var size = GUI.skin.box.CalcSize(new GUIContent(S[4]));
                        GUILayout.Box(S[4], GUILayout.Width(size.x + 5), GUILayout.Height(size.y + 5));
                  }
                  if (!string.IsNullOrEmpty(S[5]))
                  {
                        var size = GUI.skin.box.CalcSize(new GUIContent(S[5]));
                        GUILayout.Box(S[5], GUILayout.Width(size.x + 5), GUILayout.Height(size.y + 5));
                  }


                  GUILayout.EndHorizontal();

            }
      }
}