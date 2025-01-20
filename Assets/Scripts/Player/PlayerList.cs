using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerList : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer _material = default;
    [SerializeField] Text _text = null;
    [SerializeField] GameObject _mekakusi;


    void Start()
    {
        _material = transform.GetChild(1).transform.GetComponent<SkinnedMeshRenderer>();
        _mekakusi.SetActive(false);
        MateSet();
    }

    public void Select(int i)
    {
        BirdData b = BirdManager.Instance.Bird(i);
        _material.material = b.characterMaterial;
        if(!b.isUnlocked)
        {
            //�ډB��
            _mekakusi.SetActive(true);
        }
        else
        {
            _mekakusi.SetActive(false);
        }
        string unlocked = b.isUnlocked == true ? "�����Ă�" : "�����Ă��Ȃ�";
        _text.text = $"{b.ID}\n{unlocked}\nHP�@{b.Hp}\n�����@{b.Speed}\n�R�C���擾���@{b.Score}�{\n���A���e�B�@{Rarity(b.Wei)}";
    }

    public void MateSet()
    {
        BirdData bird = BirdManager.Instance.NowBird();
        Debug.Log(bird.ID);
        _material.material = bird.characterMaterial;
    }

    string Rarity(float i)
    {
        string rarity = "";
        if (i == 30) { rarity = "N"; }
        else if (i == 25) { rarity = "R"; }
        else if (i == 10) { rarity = "SR"; }
        else if (i <= 9) { rarity = "UR"; }
        return rarity;
    }
}
