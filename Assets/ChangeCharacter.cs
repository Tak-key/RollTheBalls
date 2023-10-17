using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    private int nowChara; //���݂̑���L�����̔��ʗp

    [SerializeField, Header("����L�����N�^�[���X�g")]
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
        //�ŏ��̑���L�����N�^�[���A���X�g�ɓo�^����Ă���0�Ԗڂ̃L�����N�^�[�ɂ���
        charaList[0].GetComponent<BallController>().ChangeControl(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChangeChara(nowChara); //����L�����N�^�[��؂�ւ���i���݂̃L�����N�^�[�ԍ���n���j
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
