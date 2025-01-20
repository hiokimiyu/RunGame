using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBird : MonoBehaviour
{
    public void SetBird(int i)
    {
        BirdManager.Instance.SelectBird(i);
    }
}
