using UnityEngine;
using System;

public abstract class Item_Scriptble : ScriptableObject
{
      public string _name = "";
      public consumption _consumption;
      public Sprite sprite;
      public float m_scaleFactor = 2;
      public float m_AnimPeriodTime = 3;
      public float m_FadeTime = 0.2f;
      public float m_Zoom = 3;
      public int m_LifeTime = 5;

      public Player_Parts P_Part;

      [Header("Normals")]
      public PartSetting NoramlHand;
      public PartSetting NormalLeg;
      [Header("Effects")]
      public PartSetting LeftHandset;
      public PartSetting RightHandset;
      public PartSetting LeftLegset;
      public PartSetting RightLegeset;

      public abstract Action ItemEffect();
      public abstract Action Neutralizer();
      public abstract consumption GetConsumption();

}
