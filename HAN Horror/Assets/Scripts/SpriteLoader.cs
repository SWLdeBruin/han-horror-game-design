using UnityEngine;
using UnityEngine.UI;

public class SpriteLoader : MonoBehaviour
{
    void Start()
    {
        Sprite sprite = Resources.Load<Sprite>("Sprites/Key_01");
        Debug.Log(sprite);
        this.GetComponent<Image>().sprite = sprite;
    }
}
