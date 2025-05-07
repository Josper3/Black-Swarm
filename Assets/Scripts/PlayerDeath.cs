using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public LayerMask obstacleLayer;
    public LayerMask groundLayer;

    Rigidbody2D rb;
    BoxCollider2D col;
    bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (isDead) return;

        CheckObstacleCollision();
        CheckSideGroundCollision();
    }

    // ================== COLISIONES ==================
    void CheckObstacleCollision()
    {
        if (col.IsTouchingLayers(obstacleLayer))
            Die("Tocó un obstáculo");
    }

    void CheckSideGroundCollision()
    {
        float sideRayLength = 0.1f;
        Vector2 leftOrigin  = (Vector2)transform.position + Vector2.left  * col.bounds.extents.x;
        Vector2 rightOrigin = (Vector2)transform.position + Vector2.right * col.bounds.extents.x;

        Physics2D.Raycast(leftOrigin,  Vector2.left,  sideRayLength, groundLayer);
        Physics2D.Raycast(rightOrigin, Vector2.right, sideRayLength, groundLayer);

#if UNITY_EDITOR
        Debug.DrawRay(leftOrigin,  Vector2.left  * sideRayLength, Color.red);
        Debug.DrawRay(rightOrigin, Vector2.right * sideRayLength, Color.red);
#endif
    }

    // ================== MUERTE ==================
    void Die(string reason)
    {
        if (isDead) return;
        isDead = true;

        Debug.Log("Player muerto: " + reason);

        // Detener Rigidbody
        rb.velocity        = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.bodyType        = RigidbodyType2D.Static;

        // --- NUEVO: mostrar el popup ---
        int coinsCollected = GetComponent<PlayerInventory>()?.CoinsThisRun ?? 0;
        DeathPopup.Instance.Show(coinsCollected);
    }
}
