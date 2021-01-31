using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSpot : MonoBehaviour
{
    public void StartMessage(string message, Action OnMessageEndTask = null)
    {
        DialogSystem.Instance.CallDialog(message, transform, OnMessageEndTask);
    }

}
