using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SinAnimation;

// به یکی از دست ها به صورت رندوم محدودیت زیاد می دهد
public class Bottel : MonoBehaviour, IConsumble
{
      List<GameObject> hands = new List<GameObject>();
      HingeJoint2D m_targetHand;
      JointAngleLimits2D m_OrginalLimte;

      [Header("Animation Setting")]
      [SerializeField] float m_scaleFactor = 5;
      [SerializeField] float m_AnimPeriodTime = 3;
      [SerializeField] float m_FadeTime = 0.2f;
      [SerializeField] float m_Zoom = 3;
      [SerializeField] int m_LifeTime;
      SinAnimations sinAnime = new SinAnimations();

      private void Update()
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
      public Action ItemEffect()
      {
            GetComponent<Collider2D>().enabled = false;
            Action action = () =>
            {
                  m_targetHand = hands[UnityEngine.Random.Range(0, hands.Count)].GetComponent<HingeJoint2D>();
                  m_OrginalLimte = m_targetHand.limits;
                  m_targetHand.limits = new JointAngleLimits2D() { min = -20, max = 20 };
                  StartCoroutine(sinAnime.ZoomIn(gameObject, m_Zoom, m_FadeTime, null));
                  StartCoroutine(sinAnime.FadeOut(gameObject, m_FadeTime, 0, () => { Destroy(gameObject.transform.parent.gameObject); }));
            };
            return action;
      }

      public Action neutralizer()
      {
            Action action = () =>
            {
                  m_targetHand.limits = m_OrginalLimte;

            };
            return action;
      }

      public consumption GetConsumptionType()
      {
            return consumption.Bottle;
      }
}
