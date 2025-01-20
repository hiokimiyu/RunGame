using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Animarion : MonoBehaviour
{
    Animator _anim;

    public void AnimK(string a)
    {
        //Debug.Log(GameManager.Instance.NowState);
        _anim = GetComponent<Animator>();
        _anim.SetBool("IsDead", true);
        transform.DOMoveY(5, 1f).SetEase(Ease.Linear).SetAutoKill();
        StartCoroutine(Scen(a));
    }

    IEnumerator Scen(string i)
    {
        yield return new WaitForSeconds(1f);
        var s = new ScenSquare();
        s.ScenChange(i);
    }
}
