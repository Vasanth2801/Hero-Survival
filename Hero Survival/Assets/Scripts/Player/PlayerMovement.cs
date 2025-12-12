using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("PlayerMovementSettings")]
    [SerializeField] float speed = 5f;

    [Header("References")]
    [SerializeField] Rigidbody2D rb;
    float x;
    float y;

    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 move = rb.position + new Vector2(x * speed, y * speed) * Time.deltaTime;
        rb.MovePosition(move);
    }
}