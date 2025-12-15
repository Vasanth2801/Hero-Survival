using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("PlayerMovementSettings")]
    [SerializeField] float speed = 5f;

    [Header("Shooting Settings")]
    [SerializeField] Transform firePoint;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] float duration = 0.02f;

    [Header("References")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Camera cam;
    Vector2 mousePos;
    Vector2 movement;
    
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Shoot());
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        
    }

    private void FixedUpdate()
    {
        Vector2 move = rb.position + movement * speed * Time.deltaTime;
        rb.MovePosition(move);

        MouseLook();

    }

    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up);

        if(hitInfo)
        {
            EnemyHealth enemy = hitInfo.transform.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(10);
                Debug.Log("Attacked Enemy");
            }

            lineRenderer.SetPosition(0,firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + transform.up * 100f);
        }

        lineRenderer.enabled = true;

        yield return new WaitForSeconds(duration);

        lineRenderer.enabled = false;
    }

    void MouseLook()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x)*Mathf.Rad2Deg -90f;
        rb.rotation = angle;
    }
}