using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class key : MonoBehaviour
{
      [SerializeField] int HandLayer=7;
      private void OnTriggerEnter2D(Collider2D other)
      {
            if (other.gameObject.layer == HandLayer)
            {
                  print($"{gameObject.name} trigerd with {other.name}");
            }
      }
}
