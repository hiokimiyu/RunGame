using UnityEngine;

public class Enemy : MonoBehaviour,IDmage
{
    public void Dmage()
    {
        AudioManager.Instance.PlaySE(AudioManager.SeSoundData.SE.Bump);
        gameObject.SetActive(false);
    }
}
