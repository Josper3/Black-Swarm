using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathPopup : MonoBehaviour
{
    public static DeathPopup Instance { get; private set; }

    [Header("Monedas (3 imágenes)")]
    public Image[] coinImages;      // arrastra Coin1 .. Coin3 aquí
    public Sprite fullCoin;         // moneda llena
    public Sprite emptyCoin;        // moneda vacía

    void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        // 1) Asegura que arranque oculto
        gameObject.SetActive(false);

        // 2) Asegura que el TimeScale esté en 1
        Time.timeScale = 1f;
    }

    /// <summary>Activa la ventana y muestra las monedas conseguidas (0-3).</summary>
    public void Show(int coinsCollected)
    {
        // Cambiamos sprites según las monedas conseguidas
        for (int i = 0; i < coinImages.Length; i++)
            coinImages[i].sprite = (i < coinsCollected) ? fullCoin : emptyCoin;

        gameObject.SetActive(true);   // se ve el panel
        Time.timeScale = 0f;          // pausa todo el juego
    }

    // ---------- Botones ----------
    public void Retry()              // Reintentar nivel
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToLevelSelect()    // Ir a selección de niveles
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);   // 2 = escena Seleccion_Nivel
    }

    public void GoToMainMenu()       // Menú principal
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);   // 1 = escena MainMenu
    }
}
