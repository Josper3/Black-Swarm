using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    [SerializeField, Tooltip("0 = Tutorial, 1 = Nivel 1, 2 = Nivel 2, 5 = No hay nivel")]
    private int levelIndex = 0;

    void Awake()
    {
        // Conecta el clic del botón al método Load
        GetComponent<Button>().onClick.AddListener(Load);
    }

    void Load()
    {
        GameManager.Instance.LoadLevel(levelIndex);
    }
}
