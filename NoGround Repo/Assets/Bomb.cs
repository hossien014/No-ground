using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SelectionBase]
public class CheckPoint : MonoBehaviour
{

      private void OnTriggerEnter2D(Collider2D other)
      {
            if (other.tag == "Player")
            {
                 
            }
      }
}
