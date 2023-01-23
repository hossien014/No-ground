using System.Collections.Generic;
using UnityEngine;
using System;
using Abed.Utils;
using System.Linq;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour, ISaveble
{
      Action onFall;
      Vector2 m_worlPos;
      Drager _drager;

      [SerializeField] LayerMask HandsLayer = 7;
      [SerializeField] ContactFilter2D RockFilter;
      [SerializeField] GameObject hand_R, hand_L, leg_R, legL;
      List<GameObject> HandList = new List<GameObject>();
      Tag _tag = Tag.Player;
      [SerializeField] Level currentLevel;
      [SerializeField] Vector2Int m_currentLevelKey;
      [SerializeField] public TargetJoint2D m_targetJoint;
      [SerializeField] TargetJoint2D startjoint;

      int numberOfHand;
      [SerializeField] public List<GameObject> conectedHands = new List<GameObject>();

      private void Update()
      {
            _Utils.reloadScene();
            //if (Input.GetMouseButtonUp(0)) UpdatConectedHandList(t);
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
            conectedHands.Add(startjoint.gameObject);
            //            m_currentLevelKey = FindObjectOfType<LevelManger>().GetCurrentLevel_Key();
            // currentLevel = FindObjectOfType<LevelManger>().GetCurrentLevle(currentLevelKey);
            DragerInitiation();
      }

      private void DragerInitiation()
      {
            //UpdatConectedHandList();
            //  _drager.updateConected += UpdatConectedHandList;
            _drager.OnDeSelect += ConectHandToRock;
            _drager.OnSelect += (object s, EventArgs e) =>
            {
                  var info = e as SelectInfo;
                  // UpdatConectedHandList(info.Tmep_targetjoint);
            };
      }

      //در ابتدای بازی پوزیشن پلیر را  به استارت پونیت می برد
      public void UpdatPlayerPos(Level p)
      {
            currentLevel = p;
            var offset = new Vector3(8.2f, -16.1f);
            var startPos = _Utils.GetWorldPoint(currentLevel.StartNode.transform, offset);
            transform.position = startPos;
      }

      private void ConectHandToRock(object TargetJoint2D_Obj, EventArgs e)
      {
            var info = e as SelectInfo;
            var rock = GetOverLapRock(info);
            if (!rock) return;
            var rockJoint = info.OverLapedObject.AddComponent<TargetJoint2D>();
            conectedHands.Add(rockJoint.gameObject);
            // UpdatConectedHandList(null);
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

      public void UpdatConectedHandList(TargetJoint2D? Tmpt_joint)
      {
            int HandCount = 4;
            conectedHands.Clear();
            for (int i = 0; i < HandCount; i++)
            {
                  var h = HandList[i];
                  var joint = h.GetComponent<TargetJoint2D>();
                  if (joint == null) continue;
                  // if (joint.Equals(t)) continue;

            }
            if (conectedHands.Count == 0) { NoConectedSequence(); }
      }

      void UC()
      {

      }
      void AJ(Joint2D j2)
      {

      }
      // public void removeHand(Joint2D hand)
      // {
      //       var tagets = hand.GetComponentsInChildren<TargetJoint2D>();
      //       foreach (var item in tagets)
      //       {
      //             conectedHands.Remove(item.gameObject);
      //       }
      //       if (conectedHands.Count == 0) { NoConectedSequence(); }
      //       //FindObjectOfType<FollowCamra>().DontFollowPlayer();

      // }

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

      public void CaptureState(out object objectToSave, out Tag tag)
      {
            var key = new SerializableVector3 { x = m_currentLevelKey.x, y = m_currentLevelKey.y, z = 0 };
            objectToSave = key;
            tag = Tag.Player;
      }

      public void RestoreState(object savedObject)
      {
            var key = (savedObject as SerializableVector3).ToVector();
            m_currentLevelKey = new Vector2Int(Mathf.RoundToInt(key.x), Mathf.RoundToInt(key.y));
            //UpdatPlayerPos();
      }
      public Tag GetTag() => _tag;
      public void SetCurrentLevle(Level m_currentLevel) => currentLevel = m_currentLevel;
      void ReLoadScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

      private void OnGUI()
      {
            GUILayout.BeginArea(new Rect(0, 100, 700, 700));
            GUILayout.BeginHorizontal();
            GUILayout.Box($"{conectedHands.Count} nuber of conetect hands");
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
      }
}
