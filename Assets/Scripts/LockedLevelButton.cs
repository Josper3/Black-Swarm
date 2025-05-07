using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Button))]
public class LockedLevelButton : MonoBehaviour
{
    [Tooltip("Panel que contiene el texto “Juegos por desbloquear”")]
    [SerializeField] private GameObject splashPanel;
    [Tooltip("Duración en segundos que se ve el mensaje")]
    [SerializeField] private float displayTime = 1.5f;

    private Button btn;

    void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(ShowLockedMessage);
    }

    void ShowLockedMessage()
    {
        if (splashPanel == null) return;
        splashPanel.SetActive(true);
        StartCoroutine(HideAfterDelay());
    }

    IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(displayTime);
        splashPanel.SetActive(false);
    }
}
