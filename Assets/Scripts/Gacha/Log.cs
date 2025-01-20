using UnityEngine;

public class Log : MonoBehaviour
{
    [SerializeField] GachaManager _gm;
    [SerializeField] int _coin = 100;
    float[] _gacha = new float[6];
    //‚à‚µ’¼‘O‚Éo‚µ‚½ƒLƒƒƒ‰‚ğ‚Á‚Ä‚¢‚È‚©‚Á‚½‚çtrue
    [SerializeField] bool _isUnLock = false;

    WeightedDraw _wei = default;

    private void Start()
    {
        for (int i = 0; i < BirdManager.Instance.BirdNum; i++)
        {
            _gacha[i] = BirdManager.Instance.Bird(i).Wei;
        }
        _wei = new WeightedDraw(_gacha);
    }

    public void GachaButton()
    {
        if (GameManager.Instance.Coin >= _coin)
        {
            GameManager.Instance.UseCoin(_coin);
            var index = _wei.PerformLottery();
            _isUnLock = BirdManager.Instance.SetUnlocked(index, true);
            _gm.GetGachaCharacter(index, _isUnLock);
            Debug.Log($"{BirdManager.Instance.Bird(index).ID}");
        }
        else
        {
            Debug.Log("No");
        }
    }
}