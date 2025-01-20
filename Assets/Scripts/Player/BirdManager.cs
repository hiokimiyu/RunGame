using System.IO;
using UnityEngine;

/// <summary>
/// 鳥の種類や持っている数の整理
/// </summary>
public class BirdManager : SingletonMonoBehaviour<BirdManager>
{
    /// <summary>キャラクターのステータス</summary>
    [SerializeField] TextAsset _birdFile = default;
    [SerializeField] BirdData[] _birds = new BirdData[5];

    /// <summary>対応したマテリアル</summary>
    [SerializeField] Material[] _material = new Material[5];

    /// <summary>現在の選択しているキャラクタ</summary>
    [SerializeField] int _selectIndex = 0;

    public int NowIndex { get { return _selectIndex; } }
    public int BirdNum { get { return _birds.Length; } }

    private void Awake()
    {
        for (int i = 0; i < _birds.Length; i++)
        {
            if (_material[i] != null)
            {
                _birds[i].characterMaterial = _material[i];
            }
        }
        Set();
    }

    public BirdData Bird(int i)
    {
        return _birds[i];
    }

    public bool SetUnlocked(int i, bool isUnloded)
    {
        bool unlock = _birds[i].isUnlocked;
        _birds[i].isUnlocked = isUnloded;
        return !unlock;
    }

    public void SelectBird(int i)
    {
        if (Bird(i).isUnlocked == true)
            _selectIndex = i;
    }

    public BirdData NowBird()
    {
        if (_birds[_selectIndex].isUnlocked == true)
        {
            return _birds[_selectIndex];
        }
        else
        {
            SelectBird(0);
            return _birds[0];
        }
    }

    void Set()
    {
        StringReader sr = new StringReader(_birdFile.text);

        sr.ReadLine();
        int count = 0;

        while (true)
        {
            string line = sr.ReadLine();

            if (string.IsNullOrEmpty(line))
            {
                break;
            }

            string[] value = line.Split(',');

            _birds[count].ID = int.Parse(value[0]);
            _birds[count].isUnlocked = value[1] == "1" ? true : false;
            _birds[count].Speed = int.Parse(value[2]);
            _birds[count].Hp = int.Parse(value[3]);
            _birds[count].Wei = int.Parse(value[4]);
            _birds[count].Score = int.Parse(value[5]);

            count++;
        }
    }
}