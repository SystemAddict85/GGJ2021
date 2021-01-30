using UnityEngine;

public class Item : MonoBehaviour
{
    public string name;
    public Sprite sprite;
    public Color color = Color.white;

    private void Awake()
    {
        if(sprite == null)
        {
            var rend = GetComponent<SpriteRenderer>();
            sprite = rend.sprite;
            color = rend.color;
        }

        if(name == "")
        {
            name = gameObject.name;
        }
    }
}
