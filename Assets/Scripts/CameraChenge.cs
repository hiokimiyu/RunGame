using UnityEngine;
using Cinemachine;

public class CameraChenge : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera[] _camera = new CinemachineVirtualCamera[2];
    int _priorityNum = 11;
    int _dwonNum = 10;
    bool _isGoalCamera = false;


    private void Update()
    {
        if (GameManager.Instance.NowState == GameState.Result && !_isGoalCamera)
        {
            GoalCamera();
            _isGoalCamera = true;
        }
    }

    /// <summary>
    /// goalƒJƒƒ‰‚Ö‚ÌˆÚ“®
    /// </summary>
    public void GoalCamera()
    {
        _camera[0].Priority = _dwonNum;
        _camera[1].Priority = _priorityNum;
    }
}
