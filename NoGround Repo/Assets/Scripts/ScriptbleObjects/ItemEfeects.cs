using System;
using System.Collections.Generic;
using UnityEngine;
using SinAnimation;
using UnityEditor;


[CreateAssetMenu(fileName = "ItemEffects", menuName = "NoGround/ItemEffects", order = 0)]
public class ItemEfeects : Item_Scriptble
{
      SinAnimations sinAnime = new SinAnimations();

      public override consumption GetConsumption()
      {
            return _consumption;
      }

      public override Action ItemEffect()
      {
            P_Part = FindObjectOfType<Player_Parts>();
            Action ItemEffect = () =>
                        {

                              P_Part.RightHand.GetComponent<Hand>().HandSetting = RightHandset;
                              P_Part.LeftHand.GetComponent<Hand>().HandSetting = LeftHandset;
                              P_Part.RightLeg.GetComponent<Hand>().HandSetting = RightLegeset;
                              P_Part.LeftLeg.GetComponent<Hand>().HandSetting = LeftLegset;
                              foreach (var hand in P_Part.GetHands())
                              {
                                    var handScript = hand.GetComponent<Hand>();
                                    if (handScript == null) continue;
                                    handScript.UpdateBodyPartSetting();
                              }
                        };
            return ItemEffect;
      }

      public override Action Neutralizer()
      {
            Action neutralize = () =>
             {
                   P_Part.RightHand.GetComponent<Hand>().HandSetting = NoramlHand;
                   P_Part.LeftHand.GetComponent<Hand>().HandSetting = NoramlHand;
                   P_Part.RightLeg.GetComponent<Hand>().HandSetting = NormalLeg;
                   P_Part.LeftLeg.GetComponent<Hand>().HandSetting = NormalLeg;

                   foreach (var hand in P_Part.GetHands())
                   {

                         var handScript = hand.GetComponent<Hand>();
                         if (handScript == null) continue;
                         handScript.UpdateBodyPartSetting();
                   }

             };
            return neutralize;
      }
}