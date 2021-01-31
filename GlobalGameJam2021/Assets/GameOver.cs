using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    Button _restartButton;
    private void Awake()
    {
        _restartButton = GetComponent<Button>();
        _restartButton.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene(0));
    }
}
