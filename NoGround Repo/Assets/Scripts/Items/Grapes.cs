using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SinAnimation;
using Abed.Utils;
using System.Timers;
using System;

public class Grapes : MonoBehaviour, IConsumble
{
      [Header("Animation Setting")]
      [SerializeField] float m_scaleFactor = 5;
      [SerializeField] float m_AnimPeriodTime = 3;
      [SerializeField] float m_FadeTime = 0.2f;
      [SerializeField] float m_Zoom = 3;
      [SerializeField] int m_LifeTime;
      List<GameObject> hands = new List<GameObject>();
      SinAnimations sinAnime = new SinAnimations();

      void Update()
      {
            sinAnime.ScaleWink(gameObject, m_scaleFactor, m_AnimPeriodTime);
      }

      private void OnTriggerEnter2D(Collider2D other)
      {
            GetComponent<Collider2D>().enabled = false;
            if (other.tag == Player.playertag)
            {
                  hands = FindObjectOfType<Player>().GetHands();
                  FindObjectOfType<consumptionManeger>().
                  Consum(ItemEffect(), neutralizer(), m_LifeTime, GetConsumptionType());

            }
      }

      public Action neutralizer()
      {
            Action neutralize = () =>
            {
                  foreach (var hand in hands)
                  {
                        hand.transform.GetComponent<HingeJoint2D>().useLimits = true;
                  }
            };
            return neutralize;
      }

      public Action ItemEffect()
      {
            Action ItemEffect = () =>
            {
                  foreach (var hand in hands)
                  {
                        hand.transform.GetComponent<HingeJoint2D>().useLimits = false;
                  }
                  StartCoroutine(sinAnime.ZoomIn(gameObject, m_Zoom, m_FadeTime, null));
                  StartCoroutine(sinAnime.FadeOut(gameObject, m_FadeTime, 0, () => { Destroy(gameObject.transform.parent.gameObject); }));
            };
            return ItemEffect;
      }

      public consumption GetConsumptionType()
      {
            return consumption.Grapes;
      }
}
