using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ListenEnemy : MonoBehaviour, IDmage
{
    public void Dmage()
    {
        gameObject.SetActive(false);
    }

    public void Listen()
    {
        transform.DOMoveX(-4f, 1.5f).SetEase(Ease.InOutCirc);
    }
}
