using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("EnemySettings")]
    [SerializeField] float enemySpeed = 3f;
    [SerializeField] Transform player;
    [SerializeField] PlayerHealth health;
    [SerializeField] float damage = 5f;

    private void Start()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        health = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position,player.transform.position,enemySpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
            Debug.Log("Destroyed");
        }

        if(other.gameObject.CompareTag("Player"))
        {
            health.TakeDamage(damage);
        }
    }
}