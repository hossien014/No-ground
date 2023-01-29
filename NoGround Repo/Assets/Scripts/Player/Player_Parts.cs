using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Parts : MonoBehaviour
{
      [SerializeField] public GameObject Head, Neck, Torso, LeftHand, RightHand, LeftLeg, RightLeg, RightForarem, LeftForarem, LeftDownLeg, RightDownLeg, RightUpFiger, leftUpFinger, LeftDownFinger, RightDownFinger;
      public Drager drager;
      public List<GameObject> GetHands()
      {
            List<GameObject?> hands = new List<GameObject>();
            hands.Add(RightHand);
            hands.Add(LeftHand);
            hands.Add(RightLeg);
            hands.Add(LeftLeg);
            return hands;
      }
      public GameObject[] GetFingers()
      {
            GameObject[] Fingers = { RightUpFiger, leftUpFinger, RightDownFinger, LeftDownFinger };
            return Fingers;
      }
      public void Remove(GameObject part)
      {
      }

}
