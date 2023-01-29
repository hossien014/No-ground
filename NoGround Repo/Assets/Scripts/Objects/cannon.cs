using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Abed.Utils;
using SinAnimation;
using System.Threading.Tasks;
using UnityEngine.Events;

public enum cannonBallDirction { Left, Right };
public class cannon : MonoBehaviour
{
      SinAnimations SinAnim = new SinAnimations();
      [Header("Animation Setting")]
      [SerializeField] float m_scaleFactor = 5;
      [SerializeField] float m_AnimPeriodTime = 3;
      [Header("Shoot Setting")]
      [SerializeField] float m_ShotCycle;
      [SerializeField] float force;
      [SerializeField] GameObject m_Ball;
      private void Start()
      {
            InvokeRepeating("TrigerShootAnimation", m_ShotCycle, m_ShotCycle);
      }
      private void Update()
      {
            SinAnim.ScaleWink(gameObject, m_scaleFactor, m_AnimPeriodTime);
      }
      public void TrigerShootAnimation()
      {
            GetComponent<Animator>().SetTrigger("Shoot");
      }

      void CannonShot()
      {
            //  var dirction = (dir == cannonBallDirction.Left) ? Vector2.left : Vector2.right;
            var dirction = (transform.parent.transform.localScale.x > 0) ? Vector2.left : Vector2.right;
            var ball = Instantiate(m_Ball, transform, false);
            ball.GetComponentInChildren<Rigidbody2D>().AddRelativeForce(dirction * force, ForceMode2D.Impulse);
            Destroy(ball, 6);
      }
}
