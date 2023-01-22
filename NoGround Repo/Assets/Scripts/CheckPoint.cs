using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SelectionBase]
public class CheckPoint : MonoBehaviour
{
      private void OnTriggerEnter2d(Collider other)
      {
            //save player 
            if (other.tag != "Player") return;
            FindObjectOfType<savingSystem>().save("noGroundSave");
            Destroy(this.gameObject);

      }
}
