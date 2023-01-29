using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
      public PartSetting HandSetting;
      [SerializeField] GameObject ForAram; // در پا به معنی ران است
      [SerializeField] GameObject Fingers;
      private void OnJointBreak2D(Joint2D brokenJoint)
      {
            // transform.SetParent(null);
            if (!brokenJoint) return;
            if (brokenJoint.GetComponentInChildren<TargetJoint2D>() == null) return;
            if (brokenJoint.GetComponentInChildren<TargetJoint2D>().gameObject != null)
            {
                  FindObjectOfType<Player>().removeHand(brokenJoint.GetComponentInChildren<TargetJoint2D>().gameObject);
                  FindObjectOfType<Player_Parts>().Remove(brokenJoint.GetComponentInChildren<TargetJoint2D>().gameObject);
            }
            print($"{brokenJoint.name} borked ");
      }
      private void Awake()
      {
            UpdateBodyPartSetting();
      }
      public void UpdateBodyPartSetting()
      {
            //hingJoint
            var hand = gameObject.GetComponent<HingeJoint2D>();
            if (hand != null)
            {

                  hand.enableCollision = HandSetting.EnableColliton;
                  hand.useLimits = HandSetting.useLimits;
                  hand.limits = new JointAngleLimits2D() { max = HandSetting.AngleLimte.Max, min = HandSetting.AngleLimte.Min };
                  hand.breakForce = HandSetting.BrackForce;
                  hand.breakTorque = hand.breakTorque;
                  hand.useMotor = HandSetting.useMotor;
                  if (HandSetting.useMotor)
                  {
                        hand.motor = new JointMotor2D() { motorSpeed = HandSetting.MotorSpeed, maxMotorTorque = HandSetting.MaximumMotorForce };
                  }
            }
            
            // rigidBOdy
            var r = GetComponent<Rigidbody2D>();
            if (r != null)
            {
                  r.sharedMaterial = HandSetting.physicsMaterial;
                  r.mass = HandSetting.Mass;
                  r.drag = HandSetting.Drag;
                  r.angularDrag = HandSetting.AnglarDrage;
                  r.gravityScale = HandSetting.GravityScale;
                  r.constraints = HandSetting.constraints;
            }
      }


}
