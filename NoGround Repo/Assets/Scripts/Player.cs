using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Player : MonoBehaviour
{
      Vector2 m_worlPos;
      [SerializeField] LayerMask HandsLayer = 7;
      [SerializeField] ContactFilter2D RockFilter;
      [SerializeField] GameObject hand_R, hand_L, leg_R, legL;
      Drager _drager;
      private void Awake()
      {
            _drager = FindObjectOfType<Drager>();

      }
      private void Start()
      {
            _drager.OnSelect += DisConectedRock;
            _drager.OnDeSelect += ConectHandToRock;
      }


      private void ConectHandToRock(object TargetJoint2D_Obj, EventArgs e)
      {
            var info = e as SelectInfo;
            var rock = GetOverLapRock(info);
            if (!rock) return;
            var rockJoint = info.OverLapedObject.AddComponent<TargetJoint2D>();
      }
      void DisConectedRock(object TargetJoint2D_Obj, EventArgs e)
      {
            var info = e as SelectInfo;
            var overlapCollider =info.AttachedCollider;
            var OldTargets = overlapCollider.transform.GetComponents<TargetJoint2D>();
            foreach (var target in OldTargets)
            {
                  Destroy(target);
            }
      }

      private Collider2D GetOverLapRock(SelectInfo info)
      {
            List<Collider2D> ListOfOverlapColliders = new List<Collider2D>();
            //  var info = e as SelectInfo;

            if (info.AttachedCollider == null) return null;
            int overlapCount = info.AttachedCollider.OverlapCollider(RockFilter, ListOfOverlapColliders);
            if (overlapCount == 0) return null;
            Collider2D Rock = ListOfOverlapColliders[0];
            return Rock;
      }
}
