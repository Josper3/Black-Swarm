using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer; // Capa de suelo
    public Transform groundCheck;

    private Rigidbody2D _body;
    private BoxCollider2D _box;

    private bool isGrounded;
    private float groundCheckDistance = 0.05f; // Distancia de comprobación hacia el suelo

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _box = GetComponent<BoxCollider2D>();
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
        if (hit.collider != null)
        {
            Debug.Log("Raycast grounded con: " + hit.collider.gameObject.name);
            return true;
        }
        return false;
    }

    private void Update()
    {
        // Movimiento constante hacia la derecha
        _body.velocity = new Vector2(speed, _body.velocity.y);

        // Si está en el suelo y pulsamos espacio, salta
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        _body.velocity = new Vector2(_body.velocity.x, jumpForce);
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    // Visualiza el Raycast en el editor para depuración
    private void OnDrawGizmos()
    {
        Gizmos.color = IsGrounded() ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
    private Coroutine speedBoostCoroutine;

    public void StartSpeedBoost(float multiplier, float duration)
    {
        Debug.Log("Speed boost triggered!");

        if (speedBoostCoroutine != null)
        {
            StopCoroutine(speedBoostCoroutine);
        }
        speedBoostCoroutine = StartCoroutine(SpeedBoostRoutine(multiplier, duration));
    }

    private IEnumerator SpeedBoostRoutine(float multiplier, float duration)
    {
        float originalSpeed = speed;
        speed *= multiplier;
        yield return new WaitForSeconds(duration);
        speed = originalSpeed;
    }

}
