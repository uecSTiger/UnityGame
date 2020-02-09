using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountEnemy : MonoBehaviour
{
  //　敵の総数
  GameObject[] enemys;
  //　前回Update時の敵の数
  private int oldEnemys;
  private Text EnemyText;

  void Start () {
    enemys = GameObject.FindGameObjectsWithTag("Enemy");
    oldEnemys = 0;
    EnemyText = GetComponentInChildren<Text>();
  }

  void Update () {
    //　制限時間が0秒以下なら何もしない
    if (enemys.Length <= 0) {
      return;
    }
    //　敵の総数を測定；
    enemys = GameObject.FindGameObjectsWithTag("Enemy");

    //　タイマー表示用UIテキストに時間を表示する
    if(enemys.Length != oldEnemys){
      EnemyText.text = "Enemy:" + enemys.Length.ToString("00");
    }
    oldEnemys = enemys.Length;
    //　0以下になったらコンソールに『敵全滅』という文字列を表示する
    if(enemys.Length <= 0) {
      Debug.Log("敵全滅");
      SceneManager.LoadScene("Clear");
    }
  }
}
