using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SaveData : MonoBehaviour
{
    [SerializeField] int _coin;
    [SerializeField] bool[] _birds;
    [SerializeField] int _birdIndex;

    //コインの数
    //キャラクターの解除

    private void Awake()
    {

    }
    public void Save()
    {
        _coin = GameManager.Instance.Coin;
        _birds = new bool[BirdManager.Instance.BirdNum];
        for(int i = 0; i < _birds.Length; i++)
        {
            _birds[i] = BirdManager.Instance.Bird(i).isUnlocked;
        }
        _birdIndex = BirdManager.Instance.NowIndex;
    }
    public void Load()
    {
        int a = _coin - GameManager.Instance.Coin;
        GameManager.Instance.AddCoin(a);
        for(int i = 0; i < _birds.Length;i++)
        {
            BirdManager.Instance.SetUnlocked(i, _birds[i]);
        }
        BirdManager.Instance.SelectBird(_birdIndex);
    }
}

//public struct SavePlayer
//{
//    private Transform _playerTra;
//    private string _name;

//    public SavePlayer(Transform t, string name)
//    { 
//         this._playerTra=t;
//        this._name = name;
//    }
//}