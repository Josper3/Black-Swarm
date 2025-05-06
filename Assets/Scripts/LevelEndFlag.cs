using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndFlag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entra es el jugador (puedes usar una tag)
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Nivel completado!");
            GameManager.Instance.GoToNextLevel(); // Llama al GameManager para cambiar de nivel
        }
    }
}
