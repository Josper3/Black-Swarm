using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostPickup : MonoBehaviour
{
    public float speedMultiplier = 2f;       // Cuánto se aumenta la velocidad
    public float duration = 5f;              // Cuánto dura el efecto

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered by: " + other.name);

        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.StartSpeedBoost(speedMultiplier, duration);
            Destroy(gameObject);
        }
    }
}
