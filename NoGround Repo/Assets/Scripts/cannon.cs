using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Abed.Utils;
using SinAnimation;
public enum cannonBallDirction { Left, Right };
public class cannon : MonoBehaviour
{
      SinAnimations SinAnim = new SinAnimations();
      [SerializeField] float m_scaleFactor = 5;
      [SerializeField] float m_AnimPeriodTime = 3;
      private void Update()
      {
            d.pk(() => { GetComponent<Animator>().SetTrigger("Shoot"); });
            SinAnim.ScaleWink(gameObject, m_scaleFactor, m_AnimPeriodTime);
      }
      [SerializeField] float force;
      [SerializeField] GameObject m_Ball;
      void CannonShot()
      {
            //  var dirction = (dir == cannonBallDirction.Left) ? Vector2.left : Vector2.right;
            var dirction = (transform.parent.transform.localScale.x > 0) ? Vector2.left : Vector2.right;
            var ball = Instantiate(m_Ball, transform, false);
            ball.GetComponentInChildren<Rigidbody2D>().AddRelativeForce(dirction * force, ForceMode2D.Impulse);
            Destroy(ball, 6);
      }
}
