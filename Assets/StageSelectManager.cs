using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectManager : MonoBehaviour
{
    [SerializeField, Header("カメラのトランスフォーム")]
    Transform cameraTra;

    [SerializeField, Header("カメラの回転スピード")]
    int rotateSpeed;

    [SerializeField, Header("ステージ選択ボタン")]
    Button[] stageBtn;

    const string SCENE_NAME = "Stage";

    // Start is called before the first frame update
    void Start()
    {
        //どのステージまでクリアしているのかをロード（セーブ前なら「0」）
		int clearStageNo = PlayerPrefs.GetInt ("CLEAR_STAGE_NO", 0);	

		//ステージボタンを有効化
		for (int i = 0; i <= stageBtn.GetUpperBound (0); i++) 
        {
			bool isStageClear;

			if (clearStageNo < i) {
				isStageClear = false;	//前ステージをクリアしていなければ無効
			} else {
				isStageClear = true;	//前ステージをクリアしていれば有効
			}

			//ボタンの有効／無効を設定
			stageBtn [i].interactable = isStageClear;
		}

        ButtonSettings();
    }

    // Update is called once per frame
    void Update()
    {
        cameraTra.RotateAround(cameraTra.position, Vector3.up, rotateSpeed * Time.deltaTime);
    }

    void ButtonSettings()
    {
        for (int i = 0; i < stageBtn.Length; i++)
        {
            int sceneNo = i + 1;
            stageBtn[i].onClick.AddListener(() =>
            {
                SceneManager.LoadScene(SCENE_NAME + sceneNo);
            });
        }
    }
}
