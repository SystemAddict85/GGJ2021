using System.Collections;
using System.Collections.Generic;

public class Player : SimpleSingleton<Player>
{
    public PlayerInventory inventory = new PlayerInventory();

    public override void Awake()
    {
        base.Awake();
        inventory.ClearItem();
    }
}

public class PlayerInventory
{
    private Item _activeItem = null;

    public void ChangeItem(Item newItem)
    {
        _activeItem = newItem;
        UIManager.Instance.LoadImage(newItem.sprite, newItem.color);        
    }

    public void ClearItem()
    {
        _activeItem = null;
        UIManager.Instance.ClearImage();
    }
}
