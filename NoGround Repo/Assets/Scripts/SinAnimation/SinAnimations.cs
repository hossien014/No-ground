using UnityEngine;
namespace SinAnimation
{
      public class SinAnimations
      {
            [SerializeField] AnimationType m_AnimationType;
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
            ///  اسکیل ابجکت را به صورت مداوم کم و زیاد می کند
            ///</summary>
            public void ScaleWink(GameObject Obj, float TotalScaleFactor, float Period)
            {
                  var wave = sinWave(Time.time, Period);
                  Obj.transform.localScale = Obj.transform.localScale + new Vector3(TotalScaleFactor * wave * Time.deltaTime, TotalScaleFactor * wave * Time.deltaTime, TotalScaleFactor * wave * Time.deltaTime);
            }
            ///<summary>
            ///  اسکیل ابجکت را به صورت مداوم کم و زیاد می کند
            ///</summary>
            public void ScaleWink(GameObject Obj, Vector3 ScaleFactor, float Period)
            {
                  var wave = sinWave(Time.time, Period);
                  Obj.transform.localScale = Obj.transform.localScale + new Vector3(ScaleFactor.x * wave * Time.deltaTime, ScaleFactor.y * wave * Time.deltaTime, ScaleFactor.z * wave * Time.deltaTime);
            }
            ///<summary> 
            ///بر اساس مومنت رنج یک انمیشن تکرار شونده می سازد
            ///</summary> 
            public void PlatformAnimation(GameObject obj, Vector3 MovmentRange, float period)
            {
                  var wave = sinWave(Time.time, period);
                  obj.transform.position += new Vector3(MovmentRange.x * wave * Time.deltaTime, MovmentRange.y * wave * Time.deltaTime, MovmentRange.z * wave * Time.deltaTime);
            }
      }
      public enum AnimationType { Scale };
}