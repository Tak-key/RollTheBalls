using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("�ړ��񐔃e�L�X�g")]
    TextMeshProUGUI moveCountText;

    [SerializeField, Header("�^�C�}�[�e�L�X�g")]
    TextMeshProUGUI timerText;
    public int test { get; private set; } = 10; //���N���X���琔�������邱�Ƃ͏o���邪�A���N���X�Ő����̍X�V�͂ł��Ȃ��B�����l���ݒ�ł���

    public static int test2 { get; private set;}

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

    void Update()
    {
       

        time += Time.deltaTime;

        timerText.text = $"TIME:{time.ToString("F2")}";

        moveCountText.text = $"MOVE COUNT:{moveCount}";   
    }


}
