using UnityEngine;
using UnityEngine.UI;

public class SpriteLoader : MonoBehaviour
{
    void Start()
    {
        //Inventory inventory = GetComponent<Inventory>();
        //List<Key> keys = inventory.GetKeys();
        Pickup.PickedUp += SetSprite;
    }

    public void SetSprite()
    {
        Sprite sprite = Resources.Load<Sprite>("Sprites/Key_01");
        this.GetComponent<Image>().sprite = sprite;
    }
}
