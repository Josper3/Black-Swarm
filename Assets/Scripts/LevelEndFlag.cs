using UnityEngine;

public class LevelEndFlag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        // 1) Obtiene cuántas monedas ha recogido el jugador
        int coins = other.GetComponent<PlayerInventory>()?.CoinsThisRun ?? 0;

        // 2) Muestra el popup (mismo que al morir)
        DeathPopup.Instance.Show(coins);

        // 3) Desactiva la bandera para que no entre en bucle
        GetComponent<Collider2D>().enabled = false;
    }
}
