using UnityEngine;
using System.Collections;

public class Acceleration : MonoBehaviour
{
      float m_Accelration;
      public float Accelert(float time, float number)
      {
            StartCoroutine(Acceleration_co(time, number));
            return m_Accelration;
      }
      public IEnumerator Acceleration_co(float time, float number)
      {
            m_Accelration = 0;
            while (m_Accelration < number)
            {
                  var FrameInTime = time / Time.deltaTime;
                  var EveryFrameAddOn = number / FrameInTime;
                  m_Accelration += EveryFrameAddOn;
                  Debug.Log(m_Accelration);
                  yield return null;
            }

      }
}