using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("ステージNo")]
    int stageNo;

    [SerializeField, Header("移動回数テキスト")]
    TextMeshProUGUI moveCountText;

    [SerializeField, Header("タイマーテキスト")]
    TextMeshProUGUI timerText;

    [SerializeField, Header("ゴールフラグ")]
    bool[] goalFlags = new bool[3];


    public int test { get; private set; } = 10; //他クラスから数字を見ることは出来るが、他クラスで数字の更新はできない。初期値も設定できる

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
            Debug.Log("クリア！");
        }
    }
    void Update()
    {
        time += Time.deltaTime;

        timerText.text = $"TIME:{time.ToString("F2")}";

        moveCountText.text = $"MOVE COUNT:{moveCount}";   
    }


}
