using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 15f;
    [SerializeField] float lifeTime = 5f;
    float lifeTimer;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        lifeTimer = lifeTime;

        if(rb != null)
        {
            rb.linearVelocity = transform.up * bulletSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        { 
            EnemyHealth eh = other.gameObject.GetComponent<EnemyHealth>();
            if (eh != null)
            {
                eh.TakeDamage(10);
            }

            gameObject.SetActive(false);
        }

        gameObject.SetActive(false);
    }
}
