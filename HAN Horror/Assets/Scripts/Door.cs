using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("OPEN 1");
            Inventory inventory = collision.gameObject.GetComponent<Inventory>();

            if (inventory.HasKey())
            {
                Debug.Log("OPEN");
                Quaternion targetRotation = Quaternion.Euler(0, 90, 0);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * 100f);
            }
        }
    }
}
