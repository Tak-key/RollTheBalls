using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallController : MonoBehaviour
{
    private float rayDistance = 1f; // レイを飛ばす距離

    public bool isMoving; //動いているかの判定

    private bool isControl; //操作できるかの判定
    
    void Start()
    { 
    }

    void Update()
    {
        //動いている場合・操作できない場合は反応しない
        if (isMoving || !isControl)
        {
            return;
        }

        Move();
        
    }

    void Move()
    {
        if (CanMove(Vector3.forward) && Input.GetKeyDown(KeyCode.W))
        {
            isMoving = true;
            transform.DORotate(new Vector3(180, 0, 0), 1, RotateMode.WorldAxisAdd);
            transform.DOMoveZ(transform.position.z + 1, 1).SetUpdate(UpdateType.Normal, true).OnComplete(() => 
            {
                Time.timeScale = 1;
                isMoving = false;
            });
            
            GameManager.MoveCountProp++;
            Debug.Log(GameManager.test2);
            Debug.Log(GameManager.MoveCountProp);
        }

        if (CanMove(Vector3.left) && Input.GetKeyDown(KeyCode.A))
        {
            isMoving = true;
            transform.DORotate(new Vector3(0, 0, 180), 1, RotateMode.WorldAxisAdd);
            transform.DOMoveX(transform.position.x - 1, 1).SetUpdate(UpdateType.Normal, true).OnComplete(() => 
            {
                Time.timeScale = 1;
                isMoving = false;
            });
            GameManager.MoveCountProp--;
            Debug.Log(GameManager.MoveCountProp);
        }

        if (CanMove(Vector3.back) && Input.GetKeyDown(KeyCode.S))
        {
            isMoving = true;
            transform.DORotate(new Vector3(-180, 0, 0), 1, RotateMode.WorldAxisAdd);
            transform.DOMoveZ(transform.position.z - 1, 1).SetUpdate(UpdateType.Normal, true).OnComplete(() => 
            {
                Time.timeScale = 1;
                isMoving = false;
            });
            
            GameManager.MoveCountProp++;
            Debug.Log(GameManager.test2);
            Debug.Log(GameManager.MoveCountProp);
        }

        if (CanMove(Vector3.right) && Input.GetKeyDown(KeyCode.D))
        {
            isMoving = true;
            transform.DORotate(new Vector3(0, 0, -180), 1, RotateMode.WorldAxisAdd);
            transform.DOMoveX(transform.position.x + 1, 1).SetUpdate(UpdateType.Normal, true).OnComplete(() => 
            {
                Time.timeScale = 1;
                isMoving = false;
            });
        }
    }

    //操作キャラクターのフラグ切り替えに使用
    public void ChangeControl(bool controlFlag)
    {
        isControl = controlFlag;
    }

    bool CanMove(Vector3 dir)
    {
        Vector3 rayPosition = transform.position; // レイを発射する位置の調整
        Ray ray = new Ray(rayPosition, dir);
        RaycastHit hit;

        //
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            Debug.DrawRay(rayPosition, dir, Color.yellow);
            Debug.Log("Rayが" + hit.collider.name + "にヒットしました");
            return false;
        }

        return true;
    }
}
