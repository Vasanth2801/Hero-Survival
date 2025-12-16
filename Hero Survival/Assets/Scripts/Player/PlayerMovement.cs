using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("PlayerMovementSettings")]
    [SerializeField] float speed = 5f;

    [Header("Shooting Settings")]
    [SerializeField] Transform firePoint;
    [SerializeField] ObjectPooler pooler;
    [Header("References")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Camera cam;
    Vector2 mousePos;
    Vector2 movement;

    void Start()
    {
        pooler = FindObjectOfType<ObjectPooler>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition); 
    }

    private void FixedUpdate()
    {
        Vector2 move = rb.position + movement * speed * Time.deltaTime;
        rb.MovePosition(move);

        MouseLook();
    }

    void Shoot()
    {
        pooler.SpawnObjects("Bullet",firePoint.position,firePoint.rotation);
    }

    void MouseLook()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x)*Mathf.Rad2Deg -90f;
        rb.rotation = angle;
    }
}