using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorCollition : MonoBehaviour
{
      [Header("Ignore Layer Colliton ")]
      [SerializeField] int Layer_1;
      [SerializeField] int Layer_2;
      // Start is called before the first frame update
      void Start()
      {
            Physics2D.IgnoreLayerCollision(Layer_1, Layer_2);
            Physics2D.IgnoreLayerCollision(Layer_1, Layer_1);
      }
      
}
