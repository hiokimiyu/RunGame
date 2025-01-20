using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISelect : MonoBehaviour
{
    [SerializeField] GameObject _goSelect;
    [SerializeField] Text _name;
    [SerializeField] Text _text;

    public void Exit(GameObject go)
    {
        go.SetActive(false);
    }

    public void Select(GameObject go)
    {
        go.SetActive(true);
    }
}
