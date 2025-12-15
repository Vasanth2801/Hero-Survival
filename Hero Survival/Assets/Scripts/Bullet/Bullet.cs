using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;
    Rigidbody2D bulletRb;
    [SerializeField] PlayerHealth health;
    [SerializeField] float damage = 5;

    void Start()
    {
        health = FindObjectOfType<PlayerHealth>();
        bulletRb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 moveDir = (target.position - transform.position).normalized * speed;
        bulletRb.linearVelocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            health.TakeDamage(damage);
            Debug.Log("Attacked the Player");
        }

        Destroy(this.gameObject);
    }
}
