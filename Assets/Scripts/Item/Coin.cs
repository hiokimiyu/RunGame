using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Animator _anim;
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerController>(out var player))
        {
            AudioManager.Instance.PlaySE(AudioManager.SeSoundData.SE.Coin);
            _anim.SetBool("CoinGet",true);
            StartCoroutine(Destory());
            int _score = BirdManager.Instance.NowBird().Score;
            GameManager.Instance.AddGameCoin(_score);
        }
    }

    IEnumerator Destory()
    {
        yield return new WaitForSeconds(0.2f);

        gameObject.SetActive(false);
    }
}
