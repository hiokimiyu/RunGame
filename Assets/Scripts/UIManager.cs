using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerController _pcon;

    [SerializeField] GameObject _gameOver;
    [SerializeField] GameObject _gameclear;
    [SerializeField] GameObject _game;

    [SerializeField] Text _textHP;
    [SerializeField] Text _textCoin;
    [SerializeField] Text _texttime;

    private void Update()
    {
        if (GameManager.Instance.NowState == GameState.Pouse)
        {
            _texttime.text = GameManager.Instance.Timer.ToString("0");
        }
        else { _texttime.enabled = false; }

        if (GameManager.Instance.NowState == GameState.Result)
        {
            _gameclear.SetActive(true);
            _game.SetActive(false);
        }
        else if (GameManager.Instance.NowState == GameState.GameOver)
        {
            _gameOver.SetActive(true);
            _game.SetActive(false);
        }
        else if (GameManager.Instance.NowState == GameState.Game)
        {
            _game.SetActive(true);
            _textHP.text = $"HP {_pcon.Hp}";
            _textCoin.text = $"Coin {GameManager.Instance.GameCoin}";
        }
        else if (GameManager.Instance.NowState == GameState.Pouse)
        {
            _game.SetActive(false);
            _gameOver.SetActive(false);
            _gameclear.SetActive(false);
        }
    }

    public void SetState(int i)
    {
        GameManager.Instance.SetState((GameState)Enum.ToObject(typeof(GameState), i));
    }
}
