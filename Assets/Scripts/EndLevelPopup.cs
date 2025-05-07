using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndLevelPopup : MonoBehaviour
{
    public static EndLevelPopup Instance { get; private set; }

    [Header("Texto y monedas")]
    public Text titleText;           // el texto grande arriba
    public Image[] coinImages;       // Coin1..Coin3
    public Sprite fullCoin;          // sprite moneda llena
    public Sprite emptyCoin;         // sprite moneda vacía

    [Header("Botones")]
    public GameObject btnRetry;      // contenedor (GameObject) del botón Reintentar
    public GameObject btnNext;       // contenedor del botón Siguiente nivel
    public GameObject btnSelect;     // contenedor del botón Selección de niveles
    public GameObject btnMenu;       // contenedor del botón Menú

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    /// <summary>
    /// Muestra el popup. 
    /// isVictory = true → modo victoria (se habilita Next, deshabilita Retry)
    /// isVictory = false → modo muerte (Retry sí, Next no).
    /// </summary>
    public void Show(string title, int coinsCollected, bool isVictory)
    {
        titleText.text = title;

        // monedas
        for (int i = 0; i < coinImages.Length; i++)
            coinImages[i].sprite = i < coinsCollected ? fullCoin : emptyCoin;

        // botones
        btnRetry .SetActive(!isVictory);
        btnNext  .SetActive( isVictory);
        btnSelect.SetActive(true);
        btnMenu  .SetActive(true);

        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    // ==== Eventos OnClick para tus botones ====
    public void OnRetry()          { Time.timeScale = 1f; SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
    public void OnNextLevel()      { Time.timeScale = 1f; GameManager.Instance.GoToNextLevel(0f); }
    public void OnLevelSelect()    { Time.timeScale = 1f; SceneManager.LoadScene(2); }
    public void OnMainMenu()       { Time.timeScale = 1f; SceneManager.LoadScene(1); }
}
