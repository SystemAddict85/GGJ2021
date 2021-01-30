using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SimpleSingleton<UIManager>
{
    [SerializeField]
    private Image activeImage;

    public override void Awake()
    {
        base.Awake();
        ClearImage();
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
}
