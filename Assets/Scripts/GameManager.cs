using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    /// <summary>���݂̃X�e�[�g</summary>
    [SerializeField] GameState _gameState = GameState.Game;

    GameState _beforeState = GameState.Title;

    /// <summary>�R�C��</summary>
    [SerializeField] int _coin;
    [SerializeField] int _gameCoin;

    float _time = 4f;

    public int Coin { get { return _coin; } }
    public int GameCoin { get { return _gameCoin; } }
    public GameState NowState { get { return _gameState; } }

    public GameState BeforeState { get { return _beforeState; } }

    private void Start()
    {
        State();
    }

    void Update()
    {
        if (GameState.Pouse == _gameState)
        {
            AudioManager.Instance.StopBGM();

            _time -= Time.deltaTime;

            if (_time <= 0)
            {
                SetState(GameState.Game);
                _time = 3.5f;
                AudioManager.Instance.PlayBGM(AudioManager.BgmSoundData.BGM.Title);
            }
        }

        if (_beforeState != _gameState)
        {
            Debug.Log("�X�V");
            State();
            _beforeState = _gameState; // ��Ԃ��X�V
        }
    }

    void State()
    {
        switch (_gameState)
        {
            case GameState.Title:
                AudioManager.Instance.StopBGM();
                SetState(GameState.Idle);
                Debug.Log(_gameState.ToString());
                break;

            case GameState.Gacha:
                AudioManager.Instance.StopBGM();
                AudioManager.Instance.PlayBGM(AudioManager.BgmSoundData.BGM.Gacha);
                Debug.Log(_gameState.ToString());
                break;

            case GameState.Idle:
                AudioManager.Instance.StopBGM();
                AudioManager.Instance.PlayBGM(AudioManager.BgmSoundData.BGM.Title);
                _gameCoin = 0;
                Debug.Log("�^�C�g��");
                break;

            case GameState.Game:
                AudioManager.Instance.PlayBGM(AudioManager.BgmSoundData.BGM.Game);
                Debug.Log(_gameState.ToString());
                break;

            case GameState.Result:
                AudioManager.Instance.PlayBGM(AudioManager.BgmSoundData.BGM.Clear);
                AddCoin(_gameCoin);
                Debug.Log(_gameState.ToString());
                break;

            case GameState.GameOver:
                AudioManager.Instance.PlayBGM(AudioManager.BgmSoundData.BGM.GameOver);
                AddCoin(_gameCoin);
                Debug.Log(_gameState.ToString());
                break;

            case GameState.Pouse:
                AudioManager.Instance.StopBGM();

                if (_time <= 0)
                {
                    SetState(GameState.Game);
                    _time = 3.5f;
                    AudioManager.Instance.PlayBGM(AudioManager.BgmSoundData.BGM.Title);
                }

                break;
        }
    }

    public float Timer { get { return _time; } }

    public void AddCoin(int coin)
    {
        _coin += coin;
    }

    public void AddGameCoin(int coin)
    {
        _gameCoin += coin;
    }

    public void UseCoin(int coinNum)
    {
        _coin -= coinNum;
    }
    public void SetState(GameState state)
    {
        _beforeState = _gameState;
        _gameState = state;
    }

    public void SetState(int state)
    {
        _beforeState = _gameState;
        _gameState = (GameState)state;
        Debug.Log(state.ToString());
    }
}

public enum GameState
{
    //�^�C�g��
    Title,
    //�K�`��
    Gacha,
    //�I��
    Idle,
    //�Q�[����
    Game,
    //���U���g
    Result,
    //�Q�[���I�[�o�[
    GameOver,
    //�J�E���g�_�E��
    Pouse,
}
