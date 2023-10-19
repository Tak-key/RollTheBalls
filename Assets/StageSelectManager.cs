using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectManager : MonoBehaviour
{
    [SerializeField, Header("�J�����̃g�����X�t�H�[��")]
    Transform cameraTra;

    [SerializeField, Header("�J�����̉�]�X�s�[�h")]
    int rotateSpeed;

    [SerializeField, Header("�X�e�[�W�I���{�^��")]
    Button[] stageBtn;

    const string SCENE_NAME = "Stage";

    // Start is called before the first frame update
    void Start()
    {
        //�ǂ̃X�e�[�W�܂ŃN���A���Ă���̂������[�h�i�Z�[�u�O�Ȃ�u0�v�j
		int clearStageNo = PlayerPrefs.GetInt ("CLEAR_STAGE_NO", 0);	

		//�X�e�[�W�{�^����L����
		for (int i = 0; i <= stageBtn.GetUpperBound (0); i++) 
        {
			bool isStageClear;

			if (clearStageNo < i) {
				isStageClear = false;	//�O�X�e�[�W���N���A���Ă��Ȃ���Ζ���
			} else {
				isStageClear = true;	//�O�X�e�[�W���N���A���Ă���ΗL��
			}

			//�{�^���̗L���^������ݒ�
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
