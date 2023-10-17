using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField, Header("�v���C���[")]
    BallController player;

    [SerializeField, Header("�Q�[���e�L�X�g")]
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
            Debug.Log("���܁[");
            return;
        }
        else
        {
            gameText.SetActive(true);
        }
    }
}
