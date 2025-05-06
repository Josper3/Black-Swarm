using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float trampolineForce = 20f; // Más alto que el salto normal

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(rb.velocity.x, trampolineForce);
                Debug.Log("¡Trampolín activado!");
            }
        }
    }
}

