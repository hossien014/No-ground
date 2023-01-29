using UnityEngine;

[CreateAssetMenu(fileName = "PartSetting", menuName = "NoGround/PartSetting", order = 1)]
public class PartSetting : ScriptableObject
{
      [Header("HingeJoint")]
      public bool EnableColliton=false;
      [Header("Limtes")]
      public bool useLimits=false;
      public RangedFloat AngleLimte;
      public float BrackForce =10000;
      public float BrackTorqe = Mathf.Infinity;
      [Header("Motor")]
      public bool useMotor=false;
      public float MotorSpeed = 0;
      public float MaximumMotorForce = 10000;
      [Header("RigidBody")]
      public PhysicsMaterial2D physicsMaterial;
      public float Mass=2;
      public float Drag=1;
      public float AnglarDrage=1;
      public float GravityScale=10;
      public RigidbodyConstraints2D constraints;


}