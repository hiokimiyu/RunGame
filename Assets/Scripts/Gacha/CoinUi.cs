using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUi : MonoBehaviour
{
    [SerializeField] Text _text;
    [SerializeField] GameObject _go;

    private void Update()
    {
        _text.text = $"‚P‰ñ100\nCoin {GameManager.Instance.Coin}";
        if(GameManager.Instance.Coin >= 100)
        {
            _go.SetActive(false);
        }
        else
        {
            _go.SetActive(true);
        }
    }
}
