using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class GachaTimeline : MonoBehaviour
{
    [SerializeField] PlayableDirector _director; // Playable Director���C���X�y�N�^�[����ݒ�
    [SerializeField] TimelineAsset[] _timelines; // �^�C�����C���A�Z�b�g�̔z��

    private void Start()
    {
        _director = GetComponent<PlayableDirector>();
    }

    public void PlayTimeline(int index)
    {
        if (index >= 0 && index < _timelines.Length)
        {
            _director.playableAsset = _timelines[index]; // �w�肵���^�C�����C����ݒ�
            _director.Play(); // �^�C�����C�����Đ�
        }
        else { Debug.LogError("�w�肵���C���f�b�N�X���͈͊O�ł�: " + index); }
    }
}
