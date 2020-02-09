using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
      if(transform.position.z >= 10){
        other.gameObject.transform.position =
              new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z-16);
      }else{
        other.gameObject.transform.position =
              new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z+16);
      }
    }
}
