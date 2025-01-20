using UnityEngine;
using Cinemachine;

public class CameraChenge : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera[] _camera = new CinemachineVirtualCamera[2];
    int _priorityNum = 11;
    int _dwonNum = 10;


    private void Update()
    {
        if(GameManager.Instance.NowState == GameState.Result 
            && GameManager.Instance.BeforeState == GameState.Game)
        {
            GoalCamera();
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
