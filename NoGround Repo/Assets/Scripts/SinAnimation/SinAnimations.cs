using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
                  var wave = sinWave(Period);
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
                        yield return null;
                  }
                  Callback?.Invoke();
            }
            public IEnumerator ZoomIn(GameObject obj, float UpScale, float time, Action? callBack)
            {
                  float a = 0;
                  while (a < UpScale)
                  {
                        var totalframeInTime = time / Time.deltaTime;
                        var EveyFramShareValue = UpScale / totalframeInTime;
                        a += EveyFramShareValue;
                        obj.transform.localScale += new Vector3(EveyFramShareValue, EveyFramShareValue, EveyFramShareValue);
                        yield return null;
                  }
                  callBack?.Invoke();
            }
            public IEnumerator ZoomOut(GameObject obj, float DownScale, float time, Action? callBack)
            {

                  float a = 0;
                  while (a < DownScale)
                  {
                        var totalframeInTime = time / Time.deltaTime;
                        var EveyFramShareValue = DownScale / totalframeInTime;
                        a += EveyFramShareValue;
                        obj.transform.localScale -= new Vector3(EveyFramShareValue, EveyFramShareValue, EveyFramShareValue);
                        yield return null;
                  }
                  callBack?.Invoke();
            }
            public IEnumerator FF(GameObject Obj, float FadeTime, float LowestAlpha, Action Callback)
            {
                  var sr = Obj.GetComponent<SpriteRenderer>();
                  if (!sr) { Debug.Log($"{Obj.name} Should Have Sprite Rendere"); yield break; }
                  if (LowestAlpha > 1 || LowestAlpha < 0) { Debug.Log("Max Alpha Should Be betwen 0.1 And 1 "); yield break; }
                  Color newcolor = sr.color;

                  int aa;
                  yield return null;
                  Callback?.Invoke();
            }
            public IEnumerator Acceleration_co(float time, float number)
            {
                  float m_acceleration = 0;
                  while (m_acceleration < number)
                  {
                        var FramesIntime = time / Time.deltaTime;
                        var NumberToAddInEveyFrame = number / FramesIntime;
                        m_acceleration += NumberToAddInEveyFrame;
                        Debug.Log(m_acceleration);

                        //use call back




                        //end call back
                        yield return null;
                  }
                  Debug.Log("Done");
            }
            public void RotateAnim(GameObject Obj, Vector3 _RotateRang, float Period)
            {
                  var wave = sinWave(Period);
                  var cr = Obj.transform.rotation;
                  //  _RotateRang *= wave;
                  Obj.transform.rotation = Quaternion.Euler(cr.x + (_RotateRang.x * wave), cr.x + (_RotateRang.y * wave), cr.x + (_RotateRang.z * wave));
                  print(cr.x + (_RotateRang.x * wave));
            }

      }
      public enum AnimationType
      { Scale };
}