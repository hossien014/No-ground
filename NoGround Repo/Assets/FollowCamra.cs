using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class FollowCamra : MonoBehaviour
{
      [SerializeField] Transform player;
      // Start is called before the first frame update
      void Start()
      {
        
      }

      // Update is called once per frame
      void Update()
      {
            transform.position = new Vector3(player.position.x,transform.position.y);
      }
}
