using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    Button _startButton;
    private void Awake()
    {
        _startButton = GetComponent<Button>();
        _startButton.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene(1));
    }
}
