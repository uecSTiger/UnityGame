using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
  public void OnTriggerEnter (Collider other)
  {
      if (other.CompareTag ("Explosion"))
      {
          Debug.Log (" hit by explosion!");

          // 敵を削除
          Destroy( gameObject );
      }
  }
}
