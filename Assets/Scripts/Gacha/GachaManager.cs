using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GachaManager : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer _material = default;
    [SerializeField] Text _text;
    [SerializeField] Text _newText;
    [SerializeField] GachaTimeline _timeline;
    Animator _anim;
    private void Start()
    {
        _material = transform.GetChild(1).transform.GetComponent<SkinnedMeshRenderer>();
        _anim = GetComponent<Animator>();
    }

    public void GetGachaCharacter(int i, bool unlock)
    {
        //_anim.SetBool("IsGoal", false);
        BirdData bird = BirdManager.Instance.Bird(i);
        _material.material = bird.characterMaterial;
        _text.text = bird.Wei != null ? Rarity(bird.Wei) : "No";
        _newText.gameObject.SetActive(unlock);
        int rarityNum = 0;
        if (bird.Wei >= 25) { rarityNum = 0; }
        else if (bird.Wei >= 10) { rarityNum = 1; }
        else { rarityNum = 2; }
        _timeline.PlayTimeline(rarityNum);
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
