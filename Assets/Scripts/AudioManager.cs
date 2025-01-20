using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    [Header("AudioSource")]
    [Tooltip("BGM���Đ�����AudioSource")]
    [SerializeField] AudioSource _audioBgm;
    [Tooltip("SE���Đ�����AudioSource")]
    [SerializeField] AudioSource _audioSe;

    [Space]

    [Header("AudioClip")]
    [Tooltip("BGM")]
    [SerializeField] List<BgmSoundData> _bgmSoundDatas;
    [Tooltip("SE")]
    [SerializeField] List<SeSoundData> _seSoundDatas;

    [SerializeField]
    float _masterVolume = 1;
    [SerializeField]
    float _bgmMasterVolume = 1;
    [SerializeField]
    float _seMasterVolume = 1;

    /// <summary>
    /// BGM���Đ�����悤�ɂ���
    /// </summary>
    /// <param name="bgm">�Đ�������BGM��enum</param>
    public void PlayBGM(BgmSoundData.BGM bgm)
    {
        int index = (int)bgm;
        BgmSoundData data = _bgmSoundDatas[index];
        _audioBgm.clip = data._audioClip;

        Debug.Log(bgm);

        //���ʂ̒���
        _audioBgm.volume = data._volume * _bgmMasterVolume * _masterVolume;
        _audioBgm.Play();

        Debug.Log(bgm);
    }

    public void StopBGM()
    {
        _audioBgm.Stop();
    }

    /// <summary>
    /// SE���Đ�����悤�ɂ���
    /// </summary>
    /// <param name="se">�Đ�������SE��enum</param>
    public void PlaySE(SeSoundData.SE se)
    {
        int index = (int)se;
        SeSoundData data = _seSoundDatas[index];

        Debug.Log (se);

        //���ʂ̒���
        _audioSe.volume = data.Volume * _seMasterVolume * _masterVolume;
        _audioSe.PlayOneShot(data.AudioClip);
    }



    [System.Serializable]
    public class BgmSoundData
    {
        public enum BGM
        {
            Title,
            Game,
            Gacha,
            GameOver,
            Clear,
        }

        public BGM _bgm;
        public AudioClip _audioClip;
        [Range(0f, 1f)]
        public float _volume = 1f;
    }


    [System.Serializable]
    public class SeSoundData
    {
        public enum SE
        {
            Coin,
            Brid,
            Bump,
            GameOver,
        }

        public SE Se;
        public AudioClip AudioClip;
        [Range(0, 1)]
        public float Volume = 1f;
    }
}
