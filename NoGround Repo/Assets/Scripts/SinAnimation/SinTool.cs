using UnityEngine;
using System.Collections;
namespace SinAnimation
{
      public class SinTool : MonoBehaviour
      {
            float m_Sinwave;
            public const float tua = Mathf.PI * 2f;
            ///<summary>
            /// یک موج عدد بین -1 تا 1 در هر پریود می سازد
            ///<summary>
            public float sinWave(float time, float Period)
            {
                  var Cycle = time / Period;
                  m_Sinwave = Mathf.Sin(tua * Cycle);
                  return m_Sinwave;
            }
            ///<summary>
            ///  عددی که به این فانکشن می دهید را در زمان مشخص می شمارد           
            ///</summary>
            public IEnumerator Acceleration_co(float time, float number)
            {
                float  m_acceleration = 0;
                  while (m_acceleration < number)
                  {
                        var FramesIntime = time / Time.deltaTime;
                        var NumberToAddInEveyFrame = number / FramesIntime;
                        m_acceleration += NumberToAddInEveyFrame;
                        Debug.Log(m_acceleration);
                        //use call backe
                        yield return null;
                  }
                  Debug.Log("Done");
            }
      }
}