using UnityEngine;
using System;
public class SelectInfo : EventArgs
{
      public GameObject OverLapedObject;
      public Collider2D AttachedCollider;
      public TargetJoint2D Tmep_targetjoint;
      public Vector3 worldPos;
      public SelectInfo(GameObject gameobject, Collider2D collider, TargetJoint2D Tmep_targetjoint, Vector3 worldPos)
      {
            OverLapedObject = gameobject;
            AttachedCollider = collider;
            this.Tmep_targetjoint = Tmep_targetjoint;
            this.worldPos = worldPos;

      }

}