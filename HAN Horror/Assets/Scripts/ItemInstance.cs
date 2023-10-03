using UnityEngine;

public class ItemInstance : MonoBehaviour
{
    public ItemData itemType;
    public ItemInstance(ItemData itemData)
    {
        itemType = itemData;
    }
}
