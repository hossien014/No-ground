using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SinAnimation;

public class Grapes : MonoBehaviour
{
      [SerializeField] float m_scaleFactor = 5;
      [SerializeField] float m_AnimPeriodTime = 3;
      SinAnimations sinAnime = new SinAnimations();
      void Update()
      {
            sinAnime.ScaleWink(gameObject, m_scaleFactor, m_AnimPeriodTime);
      }
      private void OnTriggerEnter2D(Collider2D other)
      {
            if (other.tag == Player.playertag)
            {
                  var hands = FindObjectOfType<Player>().Getfinger();
                  foreach (var hand in hands)
                  {
                        print(hand.transform.parent);
                        hand.transform.GetComponent<HingeJoint2D>().useLimits = false;
                  }
                  Destroy(gameObject);
            }
      }
}
