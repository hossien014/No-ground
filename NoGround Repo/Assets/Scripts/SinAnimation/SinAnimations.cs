using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SinAnimation
{
      public class SinAnimations : SinTool
      {
            [SerializeField] AnimationType m_AnimationType;

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
            ///<summary> 
            ///افکت ظاهر شدن ودر زمان تائین شده و سپس اجرای کال بک
            ///</summary> 
            public IEnumerator FadeIn(GameObject Obj, float FadeTime, float maxAlpha)
            {
                  var sr = Obj.GetComponent<SpriteRenderer>();
                  if (!sr) { Debug.Log($"{Obj.name} Should Have Sprite Rendere"); yield break; }
                  if (maxAlpha > 1 || maxAlpha <= 0) { Debug.Log("Max Alpha Should Be betwen 0.1 And 1 "); yield break; }
                  Color newcolor = sr.color;
                  while (newcolor.a < maxAlpha)
                  {
                        var totalframeInTime = FadeTime / Time.deltaTime;
                        var EveyFramShareValue = maxAlpha / totalframeInTime;
                        newcolor.a += EveyFramShareValue;
                        sr.color = newcolor;
                        yield return null;
                  }
            }
            ///<summary> 
            ///افکت محو شدن ودر زمان تائین شده و سپس اجرای کال بک
            ///</summary> 
            public IEnumerator FadeOut(GameObject Obj, float FadeTime, float LowestAlpha, Action Callback)
            {
                  var sr = Obj.GetComponent<SpriteRenderer>();
                  if (!sr) { Debug.Log($"{Obj.name} Should Have Sprite Rendere"); yield break; }
                  if (LowestAlpha > 1 || LowestAlpha < 0) { Debug.Log("Max Alpha Should Be betwen 0.1 And 1 "); yield break; }
                  Color newcolor = sr.color;
                  float maxAlpha = newcolor.a;
                  while (newcolor.a > LowestAlpha)
                  {
                        var totalframeInTime = FadeTime / Time.deltaTime;
                        var EveyFramShareValue = maxAlpha / totalframeInTime;
                        newcolor.a -= EveyFramShareValue;
                        sr.color = newcolor;
                        Debug.Log(newcolor.a);
                        yield return null;
                  }
                  Callback?.Invoke();
            }
      }


      public enum AnimationType { Scale };
}