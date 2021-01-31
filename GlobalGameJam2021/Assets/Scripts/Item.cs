using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class Item : MonoBehaviour, IInteraction
{
    public string itemName;
    public int itemId = 0;
    public Sprite itemSprite;
    [HideInInspector]
    public Color color = Color.white;

    public void Interact()
    {
        Player.Instance.inventory.ChangeItem(this);
    }

    private void Awake()
    {
        var rend = GetComponentInChildren<SpriteRenderer>();

        if(itemSprite == null)
            itemSprite = rend.sprite;

        color = rend.color;

        if (itemName == "")
        {
            itemName = gameObject.name;
        }
    }
}
