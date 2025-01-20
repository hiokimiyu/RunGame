using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetState : MonoBehaviour
{
    public void StateSet(int i)
    {
        GameManager.Instance.SetState(i);
    }
}
