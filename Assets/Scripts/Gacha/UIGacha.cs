using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGacha : MonoBehaviour
{
    [SerializeField] GameObject _text;
    [SerializeField] GameObject _bird;
    int _count = 0;

    public void On()
    {
        if (_count > 0)
        {
            _bird.transform.position = new Vector3(0, 0.1f, 17);
        }
        StartCoroutine(Stop(_text, 0f));
        _text.transform.GetChild(0).GetComponent<Text>().text = "‚à‚¤ˆê“x";
        _count++;
    }

    public void Select(GameObject go)
    {
        StartCoroutine(Stop(go, 6.5f));
        _count++;
    }

    IEnumerator Stop(GameObject i, float a)
    {
        i.SetActive(false);
        yield return new WaitForSeconds(a);
        i.SetActive(true);
    }
}
