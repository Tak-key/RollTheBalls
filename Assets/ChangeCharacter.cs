using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    private int nowChara; //現在の操作キャラの判別用

    [SerializeField, Header("操作キャラクターリスト")]
    List<GameObject> charaList;

    public GameObject[] Chara
    {
    get { return charaList.ToArray(); }
    }

    public int NowChara
    {
        get { return nowChara; }
    }

    void Start()
    {
        //最初の操作キャラクターを、リストに登録されている0番目のキャラクターにする
        charaList[0].GetComponent<BallController>().ChangeControl(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChangeChara(nowChara); //操作キャラクターを切り替える（現在のキャラクター番号を渡す）
        }
    }

    void ChangeChara(int tempCharaNo)
    {
        charaList[tempCharaNo].GetComponent<BallController>().ChangeControl(false);
        int nextChara = tempCharaNo + 1;

        //
        if (nextChara >= charaList.Count)
        {
            nextChara = 0;
        }
        charaList[nextChara].GetComponent<BallController>().ChangeControl(true);
        //targetObj = charaList[nextChara];
        nowChara = nextChara;
    }
}
