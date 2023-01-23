// این کد یک میانبر برای سریع تر کردن یکسری عملیات تکراری است 
using System;
using UnityEngine;

namespace Abed.Utils
{
      public class d
      {     /// <summary>
            /// if input.Get P key Down
            ///</summary>
            public static void pk(Action function)
            {
                  if (Input.GetKeyDown(KeyCode.P))
                  {
                        function?.Invoke();
                  }
            }
            /// <summary>
            /// if input.Get o key Down
            ///</summary>
            public static void ok(Action function)
            {
                  if (Input.GetKeyDown(KeyCode.O))
                  {
                        function?.Invoke();
                  }
            }
            /// <summary>
            /// if input.Get i key Down
            ///</summary>
            public static void ik(Action function)
            {
                  if (Input.GetKeyDown(KeyCode.I))
                  {
                        function?.Invoke();
                  }
            }
            /// <summary>
            /// if input.Get g key Down
            ///</summary>
            public static void gk(Action function)
            {
                  if (Input.GetKeyDown(KeyCode.G))
                  {
                        function?.Invoke();
                  }
            }

            /// <summary>
            /// for quie print text 
            ///</summary>
            public static void w(string print)
            {
                  Debug.Log(print);
            }
      }
}