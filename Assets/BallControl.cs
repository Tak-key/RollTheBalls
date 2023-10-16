using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallControl : MonoBehaviour
{
    private bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            isMoving = true;
            Time.timeScale = 0;
            transform.DOMoveZ(transform.position.z + 1, 1).SetUpdate(UpdateType.Normal, true).OnComplete(() => 
            {
                Time.timeScale = 1;
                isMoving = false;
            });
            GameManager.MoveCountProp++;
            Debug.Log(GameManager.test2);
            Debug.Log(GameManager.MoveCountProp);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            isMoving = true;
            Time.timeScale = 0;
            transform.DOMoveX(transform.position.x - 1, 1).SetUpdate(UpdateType.Normal, true).OnComplete(() => 
            {
                Time.timeScale = 1;
                isMoving = false;
            });
            GameManager.MoveCountProp--;
            Debug.Log(GameManager.MoveCountProp);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            isMoving = true;
            Time.timeScale = 0;
            transform.DOMoveX(transform.position.x + 1, 1).SetUpdate(UpdateType.Normal, true).OnComplete(() => 
            {
                Time.timeScale = 1;
                isMoving = false;
            });
        }
    }   
}
