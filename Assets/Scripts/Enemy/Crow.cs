using UnityEngine;

public class Crow : MonoBehaviour,IDmage
{
    public void Dmage()
    {
        AudioManager.Instance.PlaySE(AudioManager.SeSoundData.SE.Bump);
        gameObject.SetActive(false);
    }
}
