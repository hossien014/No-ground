using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Abed.Utils;
using System.Threading.Tasks;

[SelectionBase]
public class Bomb : MonoBehaviour
{
      [SerializeField] float Radius;
      [SerializeField] float Force;
      [SerializeField] float RandomForce = 0;
      [SerializeField] LayerMask layer;
      [SerializeField] string AnimationTriger = "explode";
      private void OnTriggerEnter2D(Collider2D other)
      {
            if (other.tag == "Player" || other.tag == "Hand")
            {
                  GetComponentInChildren<Animator>().SetTrigger(AnimationTriger);
            }
      }
      public void explode()
      {
            var overLapses = Physics2D.OverlapCircleAll(transform.position, Radius, layer);
            foreach (var item in overLapses)
            {
                  var dirction = item.transform.position - transform.position;
                  var top = _Utils.GetWorldPoint(item.transform, Vector2.up);
                  item.attachedRigidbody.AddForce(dirction.normalized * (Force + Random.Range(0, RandomForce)), ForceMode2D.Impulse);
            }
      }
      public void destroy()
      {
            Destroy(gameObject);

      }
      private void OnDrawGizmos()
      {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Radius);
      }
}
