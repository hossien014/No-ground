using UnityEngine;
using System;
public class SelectInfo : EventArgs
{
      public GameObject OverLapedObject;
      public Collider2D AttachedCollider;
      public TargetJoint2D AttachedTargeJoint;
      public Vector3 worldPos;
      public SelectInfo(GameObject gameobject, Collider2D collider, TargetJoint2D targetjoint, Vector3 worldPos)
      {
            OverLapedObject = gameobject;
            AttachedCollider = collider;
            AttachedTargeJoint = targetjoint;
            this.worldPos = worldPos;

      }

}