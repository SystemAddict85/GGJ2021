using UnityEngine;

[ExecuteInEditMode]
public class SpriteOutline : MonoBehaviour
{
    private Color _color = Color.white;

    [SerializeField]
    private bool isOutlineEnabled = false;

    private void Awake()
    {
        ToggleOutline(false);
    }

    private void Start()
    {
        _color = ColorManager.Instance.outlineColor;
    }

    public void Update()
    {
        ConfigureOutline();
    }

    public void ToggleOutline(bool isEnabled)
    {
        isOutlineEnabled = isEnabled;
    }

    private void ConfigureOutline()
    {
        var rend = GetComponentInChildren<SpriteRenderer>();
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();
        rend.GetPropertyBlock(mpb);
        mpb.SetFloat("_Outline", isOutlineEnabled ? 1f : 0);
        mpb.SetColor("_OutlineColor", _color);
        rend.SetPropertyBlock(mpb);
    }
}