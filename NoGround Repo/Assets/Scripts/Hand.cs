using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
      private void OnJointBreak2D(Joint2D brokenJoint)
      {
            transform.SetParent(null);
           // FindObjectOfType<Player>().removeHand(brokenJoint);
            print("asa");
      }
}
