using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class FollowCamra : MonoBehaviour
{
      [SerializeField] bool DebugVeiw = true;
      [SerializeField] TargetJoint2D Joint;
      [SerializeField] bool Is_Y_Locked;
      [SerializeField] bool Is_X_Locked;
      [SerializeField] Transform player;
      [SerializeField] float MaxDistance = 20;

      [Header("ForbiddenArea")]
      [SerializeField] bool Is_X_limited;
      [SerializeField] bool Is_Y_limited;
      [SerializeField] float X_min;
      [SerializeField] float X_max;
      [SerializeField] float Y_max;
      [SerializeField] float Y_min;
      [SerializeField] Vector3 ForbiddenArea;

      Vector3 ModifyedPos;
      float current_Frequencey;
      float DistanceFormPlayer;

      void Start()
      {
            current_Frequencey = Joint.frequency;
      }
      void Update()
      {
            DistanceFormPlayer = Vector3.Distance(transform.position, player.position);
            ModifyedPos = player.position;
          //  Lock_Y_Axis();
          //  Lock_X_Axis();
          //  X_Limitation();
          //  Y_Limitation();
           // ApplyMaxDistance();
            Joint.target = new Vector3(ModifyedPos.x, ModifyedPos.y);

      }

      private void ApplyMaxDistance()
      {
            if (DistanceFormPlayer > MaxDistance)
            {
                  Joint.frequency = 100000;
            }
            Joint.frequency = current_Frequencey;
      }

      private void Lock_Y_Axis()
      {
            if (!Is_Y_Locked) return;
            ModifyedPos.y = transform.position.y;
      }
      private void Lock_X_Axis()
      {
            if (!Is_X_Locked) return;
            ModifyedPos.x = transform.position.x;
      }

      private void X_Limitation()
      {
            if (!Is_X_limited) return;
            if (player.position.x < X_min) ModifyedPos.x = X_min;
            if (player.position.x > X_max) ModifyedPos.x = X_max;
      }
      private void Y_Limitation()
      {
            if (!Is_Y_limited) return;
            if (player.position.y < Y_min) ModifyedPos.y = Y_min;
            if (player.position.y > Y_max) ModifyedPos.y = Y_max;
      }

      private void OnDrawGizmos()
      {
            if (!DebugVeiw) return;
            Gizmos.color = Color.black;
            int range = 10000;
            //darw X Limtiation Area
            Gizmos.DrawLine(new Vector3(X_min, Y_min + range), new Vector3(X_min, Y_min - range));
            Gizmos.DrawCube(new Vector3(X_min, Y_min), new Vector3(1f, 1f));
            Gizmos.DrawLine(new Vector3(X_max, Y_max + range), new Vector3(X_max, Y_max - range));
            Gizmos.DrawCube(new Vector3(X_max, Y_max), new Vector3(1f, 1f));
            //darw Y Limtiation Area
            Gizmos.DrawLine(new Vector3(X_min + range, Y_min), new Vector3(X_min - range, Y_min));
            Gizmos.DrawCube(new Vector3(X_min, Y_min), new Vector3(1f, 1f));
            Gizmos.DrawLine(new Vector3(X_max + range, Y_max), new Vector3(X_max - range, Y_max));
            Gizmos.DrawCube(new Vector3(X_max, Y_max), new Vector3(1f, 1f));
      }
}
