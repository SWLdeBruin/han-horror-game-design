using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stamina : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] private float maxStamina = 100f;

    [Range(0, 100)]
    [SerializeField] private float currentStamina = 100f;

    // Update is called once per frame
    void Update()
    {
        // Decreasing stamina when running
        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0)
        {
            DecreaseStamina(20 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Backspace))
        {
            Debug.Log("Regenerating stamina");
            RegenStamina();
        }
    }

    // Picking up food to increase stamina
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Debug.Log("Picked up food");
            RegenStamina();
            Destroy(other.gameObject);
        }
    }


    public float MaxStamina { get => maxStamina; set => maxStamina = value; }
    public float CurrentStamina { get => currentStamina; set => currentStamina = Mathf.Clamp(value, 0, maxStamina); }

    public void RegenStamina()
    {
        if (currentStamina < maxStamina)
        {
           
            currentStamina += 20;
        }
    }

    public void DecreaseStamina(float staminaAmount)
    {
        if (currentStamina > 0)
            currentStamina -= staminaAmount;
    }

}
