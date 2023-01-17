using System.Collections.Generic;
using UnityEngine;
using System;
using Abed.Utils;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
      Action onFall;
      Vector2 m_worlPos;
      Drager _drager;

      [SerializeField] LayerMask HandsLayer = 7;
      [SerializeField] ContactFilter2D RockFilter;
      [SerializeField] GameObject hand_R, hand_L, leg_R, legL;
      List<GameObject> HandList = new List<GameObject>();

      int numberOfHand;
      [SerializeField] List<GameObject> conectedHands = new List<GameObject>();

      private void Update()
      {
            _Utils.reloadScene();
            if (Input.GetMouseButtonUp(0)) UpdatConectedHandList(null);
      }
      private void Awake()
      {
            HandList.Add(hand_R);
            HandList.Add(hand_L);
            HandList.Add(leg_R);
            HandList.Add(legL);
            _drager = FindObjectOfType<Drager>();
      }
      private void Start()
      {
            UpdatConectedHandList(null);
            _drager.updateConected += UpdatConectedHandList;
            _drager.OnDeSelect += ConectHandToRock;
            _drager.OnSelect += (object s, EventArgs e) =>
            {
                  var info = e as SelectInfo;
                  UpdatConectedHandList(info.Tmep_targetjoint);
            };
      }
      private void ConectHandToRock(object TargetJoint2D_Obj, EventArgs e)
      {
            var info = e as SelectInfo;
            var rock = GetOverLapRock(info);
            if (!rock) return;
            var rockJoint = info.OverLapedObject.AddComponent<TargetJoint2D>();
            UpdatConectedHandList(null);
      }
      void DisConectedRock(object TargetJoint2D_Obj, EventArgs e)
      {
            var info = e as SelectInfo;
            var overlapCollider = info.AttachedCollider;
            var OldTargets = overlapCollider.transform.GetComponents<TargetJoint2D>();
            foreach (var target in OldTargets)
            {
                  Destroy(target);
            }
      }
      private Collider2D GetOverLapRock(SelectInfo info)
      {
            List<Collider2D> ListOfOverlapColliders = new List<Collider2D>();
            if (info.AttachedCollider == null) return null;
            int overlapCount = info.AttachedCollider.OverlapCollider(RockFilter, ListOfOverlapColliders);
            if (overlapCount == 0) return null;
            Collider2D Rock = ListOfOverlapColliders[0];
            return Rock;
      }

      void UpdatConectedHandList(TargetJoint2D? Tmpt_joint)
      {
            int HandCount = 4;
            conectedHands.Clear();
            for (int i = 0; i < HandCount; i++)
            {
                  var joint = HandList[i].GetComponent<TargetJoint2D>();
                  if (joint == null) continue;
                  if (joint.Equals(Tmpt_joint)) continue;
                  conectedHands.Add(HandList[i]);
            }
            if (conectedHands.Count == 0) { NoConectedSequence(); }
      }

      private void NoConectedSequence()
      {
            print("you Dead");
            Destroy_Leftover_joint();
            Invoke("ReLoadScene", 1.5f);

      }

      private void Destroy_Leftover_joint()
      {
            FindObjectOfType<Drager>().enabled = false;
            foreach (var hand in HandList)
            {
                  Destroy(hand.GetComponent<TargetJoint2D>());
            }
      }

      void ReLoadScene()
      {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      }
      private void OnGUI()
      {
            GUILayout.BeginHorizontal();
            GUILayout.Box($"{conectedHands.Count} nuber of conetect hands");
            GUILayout.EndHorizontal();
      }
}
