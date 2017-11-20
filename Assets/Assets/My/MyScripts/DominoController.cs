//------------------------------------------------------------------------
//
// (C) Copyright 2017 Urahimono Project Inc.
//
//------------------------------------------------------------------------
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DominoController : MonoBehaviour
{
    [SerializeField]
    private bool m_controlled = true;
    [SerializeField]
    private float m_moveSpeed = 0.0f;
    [SerializeField]
    private float m_turnSpeed = 0.0f;
    [SerializeField, LayerTypeField]
    private int m_dominoLayer = 0;
    [SerializeField]
    private float m_torqueForce = 0.0f;

    private Rigidbody m_rigidbody = null;

    private bool m_isTopple = false;
    private Vector3 m_toppleFoward = Vector3.forward;


    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (m_controlled)
        {
            ControlObject();
        }
    }

    private void OnCollisionEnter(Collision i_collision)
    {
        if (m_isTopple)
        {
            return;
        }

        var domino = i_collision.gameObject.GetComponent<DominoController>();
        if (domino != null && domino.m_isTopple)
        {
            Topple(domino.m_toppleFoward);
        }
    }

    private void ControlObject()
    {
        Vector3 moveDir = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveDir += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDir += Vector3.back;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDir += Vector3.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDir += Vector3.left;
        }

        if (moveDir.sqrMagnitude > Mathf.Epsilon)
        {
            moveDir = moveDir.normalized;
            Turn(moveDir);
            Move(moveDir);
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            Duplication();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SetDominoParameter(this);
            Topple(transform.forward);
        }
    }

    private void Move(Vector3 i_forward)
    {
        Vector3 delta = i_forward * m_moveSpeed * Time.deltaTime;
        Vector3 targetPos = transform.position + delta;

        m_rigidbody.MovePosition(targetPos);
    }

    private void Turn(Vector3 i_forward)
    {
        Quaternion toRot = Quaternion.LookRotation(i_forward);
        Quaternion fromRot = transform.rotation;

        float delta = m_turnSpeed * Time.deltaTime;
        Quaternion targetRot = Quaternion.RotateTowards(fromRot, toRot, delta);

        m_rigidbody.MoveRotation(targetRot);
    }

    private void Duplication()
    {
        var copiedDomino = Instantiate(this, transform.position, transform.rotation);
        SetDominoParameter(copiedDomino);
    }

    private void Topple(Vector3 i_forward)
    {
        // オブジェクトの進行方向と倒す方向を内積計算する。
        // 進行方向と倒す方向のベクトルの角度が同じ方向(鋭角)なら0以上になる。
        // 進行方向と倒す方向のベクトルの角度が反対方向(鈍角)なら0未満になる。
        // 上記を利用して、前に倒れるべきか後ろに倒れるかを求める。
        bool isForward = Vector3.Dot(transform.forward, i_forward) >= 0.0f;

        // 進行方向に対してX軸で回転させたいのでrightベクトルを使用して回転ベクトルを作る。
        // 後ろに倒れる場合はleftベクトルを使いたいので、rightベクトルのマイナス値を使っている。
        Vector3 rightVec = isForward ? transform.right : -transform.right;
        Vector3 torque = rightVec * m_torqueForce;

        m_rigidbody.AddTorque(torque, ForceMode.Force);

        m_isTopple = true;
        m_toppleFoward = isForward ? transform.forward : -transform.forward;
    }

    private void SetDominoParameter(DominoController i_domino)
    {
        i_domino.m_controlled = false;
        i_domino.gameObject.layer = m_dominoLayer;
    }

} // class DominoController