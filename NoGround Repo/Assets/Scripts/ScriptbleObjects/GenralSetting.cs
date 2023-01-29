using UnityEngine;

[CreateAssetMenu(fileName = "GenralSetting", menuName = "NoGround/GenralSetting", order = 0)]
public class GenralSetting : ScriptableObject
{
      [Header("Drager")]
      public ContactFilter2D CFilter;
      [Range(0, 100)] public float m_damping = 0.1f;
      [Range(0, 100)] public float m_frequency = 100;
      public float m_maxForce = 10000;
      [Header("Ignore Layer Colliton ")]
      public int Layer_1=7;
      public int Layer_2=6;

}