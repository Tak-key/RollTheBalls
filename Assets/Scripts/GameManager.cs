using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("�X�e�[�WNo")]
    int stageNo;

    [SerializeField, Header("�ړ��񐔃e�L�X�g")]
    TextMeshProUGUI moveCountText;

    [SerializeField, Header("�^�C�}�[�e�L�X�g")]
    TextMeshProUGUI timerText;

    [SerializeField, Header("�S�[���t���O")]
    bool[] goalFlags = new bool[3];


    public int test { get; private set; } = 10; //���N���X���琔�������邱�Ƃ͏o���邪�A���N���X�Ő����̍X�V�͂ł��Ȃ��B�����l���ݒ�ł���

    public static float time { get; private set;}

    private static int moveCount; 

    public static int MoveCountProp
    {
        get { return moveCount;}
        set { moveCount = value;}
    }
    void Start()
    {
        
    }

    public void GoalCheck(int goalNo, bool goalFlag)
    {
        goalFlags[goalNo] = goalFlag;
        CheckGoalConditions();
    }

    void CheckGoalConditions()
    {
        int goalCount = 0;

        for(int i = 0; i < goalFlags.Length; i++)
        {
            if (goalFlags[i])
            {
                goalCount++;
            }
            else
            {
                goalCount = 0;
            }
        }

        if (goalCount == goalFlags.Length)
        {
            Debug.Log("�N���A�I");
        }
    }
    void Update()
    {
        time += Time.deltaTime;

        timerText.text = $"TIME:{time.ToString("F2")}";

        moveCountText.text = $"MOVE COUNT:{moveCount}";   
    }


}
