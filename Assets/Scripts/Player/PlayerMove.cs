using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// �Q�[�����̓����֘A
/// </summary>
public class PlayerMove : MonoBehaviour
{
    PlayerController _pcon;
    Animator _anim = default;
    [SerializeField] Transform _goalPos = default;
    [SerializeField] float _speed = 5f;

    /// <summary>��������܂ł̎���</summary>
    [SerializeField] float _interval = 2f;
    /// <summary>�����͈̔�</summary>
    [SerializeField] float _shutRange = 10f;
    /// <summary>���[���̍���</summary>
    [SerializeField] float[] _lanes = new float[3];
    /// <summary>��1,��0,��2</summary>
    [SerializeField] int _index = 1;

    [SerializeField] int _powr = 3;

    float _pos = 0;
    float _timer = 0;

    Rigidbody _rb = default;

    /// <summary>�v���C���[�̌����ڂȂǂ�I�����Ă�L�����ɂ���</summary>

    void Start()
    {
        _pos = transform.position.y;
        _pcon = GetComponent<PlayerController>();
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameManager.Instance.NowState == GameState.Game)
        {
            Set();
            Move();
            Animetion();
        }
        if (GameManager.Instance.NowState == GameState.GameOver)
        {
            Animetion();
        }
    }

    /// <summary>
    /// �����Č�
    /// </summary>
    void Set()
    {
        _speed = _pcon.Speed;
    }

    private void Animetion()
    {
        if (transform.position.z > _goalPos.transform.position.z)
        {
            GameManager.Instance.SetState(GameState.Result);
            transform.DOMoveY(0, 0.5f).SetEase(Ease.Linear);
            _rb.velocity = Vector3.zero;
            _anim.SetBool("IsGoal", true);
        }

        if (GameManager.Instance.NowState == GameState.GameOver)
        {
            transform.DOMoveY(0, 1.5f).SetEase(Ease.Linear);
            _rb.velocity = Vector3.zero;
            _anim.SetBool("IsDead", true);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    void Move()
    {
        _timer += Time.deltaTime;

        Vector3 vec = new Vector3(0, 0, _speed * _powr);

        if (_timer > _interval)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && _index < _lanes.Length - 1)
            {
                _index++;
                _timer = 0;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && _index > 0)
            {
                _index--;
                _timer = 0;
            }
        }


        //Vector3 pos = new Vector3(transform.position.x, _lanes[_index], transform.position.z);
        transform.DOMoveY(_lanes[_index] + _pos, _interval).SetEase(Ease.Linear);

        _rb.velocity = vec;
    }
}
