using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// プレイヤーの情報とか
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] BirdData _nowBird;

    [SerializeField]SkinnedMeshRenderer _material = default;

    [SerializeField]int _hp = 0;

    //下はMoveで必要

    float _speed = 0;

    public float Speed { get { return _speed; } }

    public int Hp { get { return _hp; } }

    void Start()
    {
        Set();
    }

    void Set()
    {
        _nowBird = BirdManager.Instance.NowBird();
        _material = transform.GetChild(1).transform.GetComponent<SkinnedMeshRenderer>();
        _material.material = _nowBird.characterMaterial;
        Debug.Log(_nowBird.Hp);
        _hp = _nowBird.Hp;
        _speed = _nowBird.Speed;
    }

    void Update()
    {
        if(_hp <= 0 && GameManager.Instance.NowState == GameState.Game)
        {
            GameManager.Instance.SetState(GameState.GameOver);
        }
    }

    void HpDamage()
    {
        _hp--;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IDmage>(out var enemy))
        {
            enemy.Dmage();
            HpDamage();
        }
    }
}
