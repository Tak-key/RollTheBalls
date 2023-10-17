using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField, Header("プレイヤー")]
    BallController player;

    [SerializeField, Header("ゲームテキスト")]
    GameObject gameText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (player.isMoving)
        {
            Debug.Log("だまー");
            return;
        }
        else
        {
            gameText.SetActive(true);
        }
    }
}
