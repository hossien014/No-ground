using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SinAnimation;

public class Item : MonoBehaviour, ISerializationCallbackReceiver
{
      [SerializeField] Item_Scriptble ScriptObj;
      Sprite sprite;
      [SerializeField] public float m_scaleFactor;
      [SerializeField] public float m_AnimPeriodTime;
      [SerializeField] public float m_FadeTime;
      [SerializeField] public float m_Zoom;
      [SerializeField] public int m_LifeTime;
      [Header("sinAnime")]
      SinAnimations sinAnime = new SinAnimations();
      [SerializeField] bool IsWinke = true;
      [SerializeField] bool IsRotate = false;
      [SerializeField] float RotatePeriod;
      [SerializeField] Vector3 RotateRange;


      private void Awake()
      {
            GetComponent<SpriteRenderer>().sprite = ScriptObj.sprite;
            m_scaleFactor = ScriptObj.m_scaleFactor;
            m_AnimPeriodTime = ScriptObj.m_AnimPeriodTime;
            m_FadeTime = ScriptObj.m_FadeTime;
            m_Zoom = ScriptObj.m_Zoom;
            m_LifeTime = ScriptObj.m_LifeTime;
      }
      private void LateUpdate()
      {
            if (IsWinke)
            {
                  sinAnime.ScaleWink(gameObject, m_scaleFactor, m_AnimPeriodTime);
            }
            if (IsRotate)
            {
                  sinAnime.RotateAnim(gameObject, RotateRange, RotatePeriod);
            }
      }
      private void OnTriggerEnter2D(Collider2D other)
      {

            GetComponent<Collider2D>().enabled = false;
            if (other.tag == Player.playertag)
            {
                  FindObjectOfType<consumptionManeger>().Consum(ScriptObj.ItemEffect(),
                  ScriptObj.Neutralizer(), m_LifeTime, ScriptObj.GetConsumption()
                  );
                  StartCoroutine(sinAnime.ZoomIn(gameObject, m_Zoom, m_FadeTime, null));
                  StartCoroutine(sinAnime.FadeOut(gameObject, m_FadeTime, 0, () => { Destroy(gameObject); }));

            }

      }
      public void OnAfterDeserialize()
      {
            //  m_scaleFactor = ScriptObj.m_scaleFactor;
            //  m_AnimPeriodTime = ScriptObj.m_AnimPeriodTime;
            //  m_FadeTime = ScriptObj.m_FadeTime;
            //  m_Zoom = ScriptObj.m_Zoom;
            //            m_LifeTime = ScriptObj.m_LifeTime;
      }
      public void updateSprite()
      {
            GetComponent<SpriteRenderer>().sprite = ScriptObj.sprite;
            transform.name = ScriptObj._name;
      }
      public void OnBeforeSerialize() { }

}
