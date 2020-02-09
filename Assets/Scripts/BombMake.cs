using UnityEngine;
using System.Collections;
using System;

public class BombMake : MonoBehaviour
{

    public bool canDropBombs = true;
    //Can the player drop bombs?

    //Prefabs
    public GameObject bombPrefab;

    //Cached components
    private Rigidbody rigidBody;
    private Transform myTransform;

    // Use this for initialization
    void Start ()
    {
        //Cache the attached components for better performance and less typing
        rigidBody = GetComponent<Rigidbody> ();
        myTransform = transform;
    }

    // Update is called once per frame
    void Update ()
    {
    //  if (canDropBombs && Input.GetKeyDown (KeyCode.Space))
      if (canDropBombs && Input.GetKeyDown (KeyCode.B))
      { //Drop bomb
          DropBomb ();
      }
    }

    /// <summary>
    /// Drops a bomb beneath the player
    /// </summary>
    private void DropBomb ()
    {
        if (bombPrefab)
        {
          // X 座標と Y 座標を四捨五入
          var pos = new Vector3( Mathf.RoundToInt( myTransform.position.x ), myTransform.position.y+bombPrefab.transform.position.y,
                                Mathf.RoundToInt( myTransform.position.z ));
          // 爆弾のゲームオブジェクトを作成
          Instantiate( bombPrefab, pos, bombPrefab.transform.rotation);
        }
    }
}
