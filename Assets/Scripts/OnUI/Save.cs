using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public void OnSave()
    {
        SaveLoadManager.Instance.SaveAction();
    }
}
