using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoalBlock : MonoBehaviour
{
    [SerializeField, Header("ゲームマネージャー")]
    GameManager gameManager;

    [SerializeField, Header("プレイヤータグ")]
    string playerTag;

    [SerializeField, Header("ゴール番号")]
    int goalNo;

    BallController ballScript; //ボールのスクリプトを収納

    void Start()
    {
        
    }

    void Update()
    {
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            ballScript = collision.gameObject.GetComponent<BallController>();

            if (ballScript.isMoving) //ボールが動いている間は処理をしない
            {
                return;
            }
            else
            {
                //ゲームマネージャーの、ゴールナンバーに応じたフラグをtrueにする
                gameManager.GoalCheck(goalNo, true);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //ゲームマネージャーの、ゴールナンバーに応じたフラグをfalseにする
        gameManager.GoalCheck(goalNo, false);
    }
}
