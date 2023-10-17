using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallController : MonoBehaviour
{
    private float rayDistance = 1f; // ���C���΂�����

    [HideInInspector]
    public bool isMoving; //�����Ă��邩�̔���

    private bool isControl; //����ł��邩�̔���

    [SerializeField, Header("�������郌�C���[")]
    LayerMask ignoreLayer;
    
    void Start()
    { 
    }

    void Update()
    {
        //�����Ă���ꍇ�E����ł��Ȃ��ꍇ�͔������Ȃ�
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
                isMoving = false;
            });
            
            GameManager.MoveCountProp++;
        }

        if (CanMove(Vector3.left) && Input.GetKeyDown(KeyCode.A))
        {
            isMoving = true;
            transform.DORotate(new Vector3(0, 0, 180), 1, RotateMode.WorldAxisAdd);
            transform.DOMoveX(transform.position.x - 1, 1).SetUpdate(UpdateType.Normal, true).OnComplete(() => 
            {
                isMoving = false;
            });

            GameManager.MoveCountProp++;
        }

        if (CanMove(Vector3.back) && Input.GetKeyDown(KeyCode.S))
        {
            isMoving = true;
            transform.DORotate(new Vector3(-180, 0, 0), 1, RotateMode.WorldAxisAdd);
            transform.DOMoveZ(transform.position.z - 1, 1).SetUpdate(UpdateType.Normal, true).OnComplete(() => 
            {
                isMoving = false;
            });
            
            GameManager.MoveCountProp++;
        }

        if (CanMove(Vector3.right) && Input.GetKeyDown(KeyCode.D))
        {
            isMoving = true;
            transform.DORotate(new Vector3(0, 0, -180), 1, RotateMode.WorldAxisAdd);
            transform.DOMoveX(transform.position.x + 1, 1).SetUpdate(UpdateType.Normal, true).OnComplete(() => 
            {
                isMoving = false;
            });

            GameManager.MoveCountProp++;
        }
    }

    //����L�����N�^�[�̃t���O�؂�ւ��Ɏg�p
    public void ChangeControl(bool controlFlag)
    {
        isControl = controlFlag;
    }

    bool CanMove(Vector3 dir)
    {
        Vector3 rayPosition = transform.position; // ray�𔭎˂���ʒu�̒���
        Ray ray = new Ray(rayPosition, dir); //rayPosition����Adir�̕�����ray�𔭎�
        RaycastHit hit; //ray�Ƀq�b�g�����I�u�W�F�N�g�������[

        //ray�Ƀq�b�g�����I�u�W�F�N�g�̃��C���[��Playar��������false��Ԃ�
        //��������Ȃ��Ȃ�true
        if (Physics.Raycast(ray, out hit, rayDistance, ignoreLayer))
        {
            Debug.DrawRay(rayPosition, dir, Color.red);
            return false;
        }
        else
        {
            return true;
        }
    }
}
