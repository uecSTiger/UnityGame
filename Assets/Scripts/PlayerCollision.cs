using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public GameObject damageUI;
    private bool hit = false;
    [SerializeField] float hp = 3f;

    public void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag ("Explosion"))
        {
          if(!hit){
              hp--;
              // オブジェクトを削除
              if(hp <= 0){
                //Destroy( gameObject );
                SceneManager.LoadScene("GameOver");
              }else{
                hit = true;
                Debug.Log (" hit by explosion!"+"HP:"+hp);
                Invoke("HitAgain", 2.0f);
              }
          }
        }

        if (other.CompareTag ("Enemy")){
            if(!hit){
              hp--;
              Debug.Log (" hit by enemy!"+"HP:"+hp);
              // オブジェクトを削除
              if(hp <= 0){
                //Destroy( gameObject );
                SceneManager.LoadScene("GameOver");
              }else{
                hit = true;
                damageUI.GetComponent<Image>().color = new Color(0.5f, 0f, 0f, 0.5f);
                Invoke("HitAgain", 2.0f);
              }
            }
        }
    }

    void HitAgain(){
      hit = false;
    }

}
