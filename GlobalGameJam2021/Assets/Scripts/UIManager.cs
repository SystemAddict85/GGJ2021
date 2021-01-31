using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SimpleSingleton<UIManager>
{
    [SerializeField]
    private Image activeImage;
        
    public TextMeshProUGUI buttonHelpText;


    public override void Awake()
    {
        base.Awake();
        ClearImage();
        ToggleCanvas(false);
    }

    public void ClearImage()
    {
        LoadImage(null, Color.clear);
    }
    public void LoadImage(Sprite sprite, Color color)
    {
        activeImage.sprite = sprite;
        activeImage.color = color;
    }

    public void ToggleCanvas(bool isEnabled)
    {
        GetComponent<Canvas>().enabled = isEnabled;
        if (isEnabled == false)
        {
            buttonHelpText.enabled = false;
            ClearImage();
        }
    }
}
