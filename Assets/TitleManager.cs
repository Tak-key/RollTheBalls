using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField, Header("スタートボタン")]
    Button startBtn;

    const string NEXT_SCENE_NAME = "StageSelect";

    // Start is called before the first frame update
    void Start()
    {
        ButtonSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ButtonSettings()
    {
        startBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(NEXT_SCENE_NAME);
        });
    }
}
