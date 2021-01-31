using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : SimpleSingleton<DialogSystem>
{
    private CanvasGroup _cg;
    private TextMeshProUGUI _tmPro;

    private bool _isMessageAlreadyCalled = false;
    [SerializeField]
    private float maxMessageTime = 4f;

    public Action OnMessageFinish;
    private float _currentTime = 0f;

    public void Awake()
    {
        base.Awake();
        _cg = GetComponent<CanvasGroup>();
        _tmPro = GetComponentInChildren<TextMeshProUGUI>();
        ToggleCanvasGroup(false);
    }

    private void ToggleCanvasGroup(bool isEnabled)
    {
        _cg.interactable = isEnabled;
        _cg.alpha = isEnabled ? 1f : 0f;
        _cg.blocksRaycasts = isEnabled;
    }

    private void Update()
    {
        if (_isMessageAlreadyCalled == true)
        {
            _currentTime += Time.deltaTime;
            CheckForMessageFinish();
        }
    }

    private void CheckForMessageFinish()
    {
        if (_currentTime >= maxMessageTime)
        {
            FinishMessage();
        }
    }

    private void FinishMessage()
    {
        _currentTime = 0f;
        OnMessageFinish?.Invoke();
        ToggleCanvasGroup(false);
        _isMessageAlreadyCalled = false;
    }

    public void CallDialog(string message, Transform parentTransform, Action OnMessageFinishTask = null)
    {
        if (_isMessageAlreadyCalled)
        {
            FinishMessage();
        }

        if (OnMessageFinishTask != null)
            OnMessageFinish += OnMessageFinish;
        
        _isMessageAlreadyCalled = true;
        ToggleCanvasGroup(true);
        transform.GetComponent<RectTransform>().SetParent(parentTransform);
        transform.localPosition = Vector3.zero;
        _tmPro.text = message;
    }
}
