using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CoinPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Sumar una moneda al contador del jugador
            var inv = other.GetComponent<PlayerInventory>();
            if (inv != null) inv.CollectCoin();

            // TODO: aquí puedes reproducir sonido o partículas

            Destroy(gameObject);           // desaparece la moneda
        }
    }
}
