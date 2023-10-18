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
    Button[] stageSelectBtn;

    const string SCENE_NAME = "Stage";

    // Start is called before the first frame update
    void Start()
    {
        ButtonSettings();
    }

    // Update is called once per frame
    void Update()
    {
        cameraTra.RotateAround(cameraTra.position, Vector3.up, rotateSpeed * Time.deltaTime);
    }

    void ButtonSettings()
    {
        for (int i = 0; i < stageSelectBtn.Length; i++)
        {
            int sceneNo = i + 1;
            stageSelectBtn[i].onClick.AddListener(() =>
            {
                SceneManager.LoadScene(SCENE_NAME + sceneNo);
            });
        }
    }
}
