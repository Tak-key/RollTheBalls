using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoalBlock : MonoBehaviour
{
    [SerializeField, Header("�Q�[���}�l�[�W���[")]
    GameManager gameManager;

    [SerializeField, Header("�v���C���[�^�O")]
    string playerTag;

    [SerializeField, Header("�S�[���ԍ�")]
    int goalNo;

    BallController ballScript; //�{�[���̃X�N���v�g�����[

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

            if (ballScript.isMoving)
            {
                return;
            }
            else
            {
                gameManager.GoalCheck(goalNo, true);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
            gameManager.GoalCheck(goalNo, false);
    }
}
