using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class border : MonoBehaviour
{
      // Start is called before the first frame update
      void Start()
      {
            var collider = GetComponent<BoxCollider2D>();
            Physics2D.alwaysShowColliders = false;

      }

      // Update is called once per frame
      void Update()
      {

            if (Application.isEditor)
            {

                  Physics2D.alwaysShowColliders = true;
            }
      }
}
