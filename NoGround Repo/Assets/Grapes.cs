using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SinAnimation;
using Abed.Utils;

public class Grapes : MonoBehaviour
{
      [SerializeField] float m_scaleFactor = 5;
      [SerializeField] float m_AnimPeriodTime = 3;
      [SerializeField] float FadeTime=0.2f;
      SinAnimations sinAnime = new SinAnimations();
      void Update()
      {
            sinAnime.ScaleWink(gameObject, m_scaleFactor, m_AnimPeriodTime);
      }

      private void OnTriggerEnter2D(Collider2D other)
      {
            if (other.tag == Player.playertag)
            {
                  var hands = FindObjectOfType<Player>().GetHands();
                  foreach (var hand in hands)
                  {
                        hand.transform.GetComponent<HingeJoint2D>().useLimits = false;
                  }
                  StartCoroutine(sinAnime.FadeOut(gameObject, FadeTime, 0, () => { Destroy(gameObject.transform.parent.gameObject); }));

            }
      }
}
