using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class Item : MonoBehaviour, IInteraction
{
    public string itemName;
    [HideInInspector]
    public Sprite sprite;
    [HideInInspector]
    public Color color = Color.white;

    public void Interact()
    {
        Player.Instance.inventory.ChangeItem(this);
    }

    private void Awake()
    {
        var rend = GetComponent<SpriteRenderer>();
        sprite = rend.sprite;
        color = rend.color;

        if (itemName == "")
        {
            itemName = gameObject.name;
        }
    }
}
