using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraControl : MonoBehaviour
{
    [SerializeField, Header("ターゲットするオブジェクト")]
    GameObject targetObj;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, targetObj.transform.position.z -2);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.01f, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-0.01f, 0, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0.01f, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -0.01f, 0);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.DOMoveX(3, 1).SetRelative(true);
            transform.DORotate(new Vector3(0, -90, 0), 1, RotateMode.WorldAxisAdd);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.DOMoveX(-3, 1).SetRelative(true);
            transform.DORotate(new Vector3(0, 90, 0), 1, RotateMode.WorldAxisAdd);
        }
    }
}
