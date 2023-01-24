using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
      private void OnJointBreak2D(Joint2D brokenJoint)
      {
            // transform.SetParent(null);
            if (!brokenJoint) return;
            if (brokenJoint.GetComponentInChildren<TargetJoint2D>() == null) return;
            if (brokenJoint.GetComponentInChildren<TargetJoint2D>().gameObject != null)
            {
                  FindObjectOfType<Player>().removeHand(brokenJoint.GetComponentInChildren<TargetJoint2D>().gameObject);
            }
            print($"{brokenJoint.name} borked ");
      }
}
