using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene2Menu : MonoBehaviour {
  private float step_time;    // 経過時間カウント用
  [SerializeField] float limit;

  // Use this for initialization
  void Start()
  {
      step_time = 0.0f;       // 経過時間初期化
  }

  // Update is called once per frame
  void Update()
  {
      // 経過時間をカウント
      step_time += Time.deltaTime;

      // 3秒後に画面遷移（scene2へ移動）
      if (step_time >= limit)
      {
          SceneManager.LoadScene("Menu");
      }
  }
}
