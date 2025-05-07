using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int CoinsThisRun { get; private set; }   // 0‑3

    /// Recibe la llamada del pickup
    public void CollectCoin()
    {
        if (CoinsThisRun < 3) CoinsThisRun++;
    }

    /// Llama a esto al empezar / reiniciar nivel si quieres resetear
    public void ResetRun() => CoinsThisRun = 0;
}
