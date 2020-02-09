using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    private Vector3 Player_pos;

    //Rigidbodyを入れる
    Rigidbody rb;
    //移動スピード
    public float speed = 2f;
    public float rotspeed = 2f;
    //ジャンプ力
    public float thrust = 150;

    //Animatorを入れる変数
    private Animator animator;

    //ユニティちゃんを入れる
    [SerializeField] private GameObject unityChan;

    //前後左右移動とそのアニメーションへの遷移を止める
    [SerializeField]bool stopMove;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //A・Dキー、←→キーで横移動
        float h = CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * speed;
        //W・Sキー、↑↓キーで前後移動
        float v = CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime * speed;


        //Trueの時は前後左右移動とそのアニメーションへの遷移が可能
        if (stopMove){
            //前移動
            if (v > 0){
                transform.position += transform.forward * speed * Time.deltaTime;
                //前走りのアニメーションへ遷移
                animator.SetBool("Front", true);
            }
            else{
                //前走りのアニメーションからExitへ遷移
                animator.SetBool("Front", false);
            }

            //後ろ移動
            if(v < 0){
                transform.position -= transform.forward * speed * Time.deltaTime;
                animator.SetBool("Back", true);
            }
            else{
                animator.SetBool("Back", false);
            }

            //右移動
            if(h > 0){
                transform.Rotate(0, rotspeed * 50 * Time.deltaTime, 0, 0);
                animator.SetBool("Right", true);
            }
            else{
                animator.SetBool("Right", false);
            }

            //左移動
            if(h < 0){
                transform.Rotate(0, -rotspeed * 50 * Time.deltaTime, 0);
                animator.SetBool("Left", true);
            }else{
                animator.SetBool("Left", false);
            }

        }
        //stopMoveがFalseになったら前後左右移動アニメからExitに遷移する
        else{
            animator.SetBool("Front", false);
            animator.SetBool("Back", false);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
        }

        //Playerの位置に前方ｘ上下キーと右方向ｘ左右キーの値を加え続けて移動



        //Jumpはスペースキーかジョイスティックのボタン3
        //それらとstopMove変数がTrueの時ジャンプできる
        if (Input.GetButton("Jump") && stopMove){
            //前後左右移動アニメをオフにする
            animator.SetBool("Front", false);
            animator.SetBool("Back", false);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);

            //thrustの分だけ上方に力がかかる
            rb.AddForce(transform.up * thrust);
            //CharacterController上のどこを遷移していてもJumpアニメーションを出せる
            animator.Play("Jump");
        }
    }

    //GroundDecisionスクリプトから呼び出す
    public void GroundDecisionTrue(){
        //地面にGroundDecisionのコライダーが触れていたらTrue
        stopMove = true;
        //地面に触れている時はジャンプアニメーション出ない
        animator.SetBool("Jump", false);
    }

    //GroundDecisionスクリプトから呼び出す
    public void GroundDecisionFalse(){
        //地面からGroundDecisionのコライダーが離れたらFalse
        stopMove = false;
    }
}
