using System.Collections;
using System.Collections.Generic;
using Abed.Utils;
using UnityEngine;
using System;

public class Drager : MonoBehaviour
{
      public event EventHandler OnHover;
      public event EventHandler OnSelect;
      public event EventHandler OnDeSelect;
      Vector3 WorldPos;
      TargetJoint2D m_targetJoint;
      [SerializeField] ContactFilter2D CFilter;
      [SerializeField] LayerMask TargetMask;
      [SerializeField][Range(0, 100)] float m_damping = 0.1f;
      [SerializeField][Range(0, 100)] float m_frequency = 100;
      [SerializeField] float m_maxForce = 10000;
      [SerializeField] bool DebugLine;

      void Update()
      {
            WorldPos = _Utils.Worldpos2D();
            HoverSensor();
            if (Input.GetMouseButtonDown(0))
            {
                  List<Collider2D> contactList = new List<Collider2D>();
                  if (Physics2D.OverlapPoint(WorldPos, CFilter, contactList) == 0) return;
                  var Overlapcollider = contactList[0];
                  if (!Overlapcollider) return;
                // RemoveOldTargetJoints(Overlapcollider);
                  OnSelect?.Invoke(Overlapcollider, new SelectInfo(Overlapcollider.gameObject,Overlapcollider,null,WorldPos));
                  AddTargetJoint(Overlapcollider);

            }
            if (Input.GetMouseButtonUp(0))
            {
                  if (!m_targetJoint) return;
                  var info = new SelectInfo(m_targetJoint.gameObject, m_targetJoint.GetComponent<Collider2D>(), m_targetJoint, WorldPos);
                  OnDeSelect?.Invoke(m_targetJoint, info);
                  RemoveTargetJoint();
            }

            void AddTargetJoint(Collider2D Overlapcollider)
            {
                  var body = Overlapcollider.attachedRigidbody;
                  if (!body) return;
                  m_targetJoint = body.gameObject.AddComponent<TargetJoint2D>();
                  body.GetComponent<Hand>();
                  m_targetJoint.frequency = m_frequency;
                  m_targetJoint.dampingRatio = m_damping;
                  m_targetJoint.maxForce=m_maxForce;
                  //inverse form point یعنی پوزیشتی که به تو میدهم را تبدیل به لوکال خودت کن
                  m_targetJoint.anchor = m_targetJoint.transform.InverseTransformPoint(WorldPos);
            }
            if (m_targetJoint)
            {
                  m_targetJoint.target = WorldPos;
                  if (DebugLine) Debug.DrawLine(m_targetJoint.anchor, WorldPos, Color.black);
            }
      }

      private static void RemoveOldTargetJoints(Collider2D Overlapcollider)
      {
            var OldTargets = Overlapcollider.transform.GetComponents<TargetJoint2D>();
            foreach (var target in OldTargets)
            {
                  Destroy(target);
            }
      }

      private void RemoveTargetJoint()
      {
            var leftOver = m_targetJoint.attachedRigidbody.GetComponent<TargetJoint2D>();
            if (leftOver) Destroy(leftOver);
            Destroy(m_targetJoint);
            m_targetJoint = null;
      }

      public Collider2D HoverSensor()
      {
            Collider2D overlapCollider = Physics2D.OverlapPoint(WorldPos, TargetMask);
            if (!overlapCollider) return null;
            OnHover?.Invoke(overlapCollider, EventArgs.Empty);
            return overlapCollider;
      }

      #region Gui
      private void OnGUI()
      {
            GUILayout.BeginHorizontal();
            var size = GUI.skin.box.CalcSize(new GUIContent(WorldPos.ToString()));
            GUILayout.Box(WorldPos.ToString(), GUILayout.Width(size.x + 5), GUILayout.Height(size.y + 5));
            GUILayout.EndHorizontal();
      }
      #endregion

}
