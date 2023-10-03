using System;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Inventory inventory;

    public SpriteLoader spriteLoader;

    private RaycastHit hit;

    public static event Action PickedUp;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
        spriteLoader = GetComponent<SpriteLoader>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
            {
                Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.red);
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.name == "Key_01")
                {
                    Debug.Log("hit");
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Key"))
        {
            Key key = ScriptableObject.CreateInstance<Key>();
            inventory.AddItem(key);
            Destroy(other.gameObject);

            PickedUp.Invoke();
        }
    }
}
