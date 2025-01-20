using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class GachaTimeline : MonoBehaviour
{
    [SerializeField] PlayableDirector _director; // Playable Directorをインスペクターから設定
    [SerializeField] TimelineAsset[] _timelines; // タイムラインアセットの配列

    private void Start()
    {
        _director = GetComponent<PlayableDirector>();
    }

    public void PlayTimeline(int index)
    {
        if (index >= 0 && index < _timelines.Length)
        {
            _director.playableAsset = _timelines[index]; // 指定したタイムラインを設定
            _director.Play(); // タイムラインを再生
        }
        else { Debug.LogError("指定したインデックスが範囲外です: " + index); }
    }
}
