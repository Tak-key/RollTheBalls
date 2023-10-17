using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("移動回数テキスト")]
    TextMeshProUGUI moveCountText;

    [SerializeField, Header("タイマーテキスト")]
    TextMeshProUGUI timerText;
    public int test { get; private set; } = 10; //他クラスから数字を見ることは出来るが、他クラスで数字の更新はできない。初期値も設定できる

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
