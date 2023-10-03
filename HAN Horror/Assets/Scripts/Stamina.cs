using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stamina : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] private float maxStamina = 100f;

    [Range(0, 100)]
    [SerializeField] private float currentStamina = 100f;

    [SerializeField] private float staminaDecreaseRate = 20f;

    // Update is called once per frame
    void Update()
    {
        // Decreasing stamina when running
        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0)
        {
            DecreaseStamina(staminaDecreaseRate * Time.deltaTime);
        }
    }

    // Picking up food to increase stamina
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            RegenStamina();
            Destroy(other.gameObject);
        }
    }

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

    public float getCurrentStamina()
    {
        return currentStamina;
    }
}
