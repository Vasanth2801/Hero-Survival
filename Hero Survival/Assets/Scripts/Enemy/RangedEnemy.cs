using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] float enemySpeed = 5f;
    [SerializeField] Transform player;
    [SerializeField] float rotationSpeed = 0.0025f;

    [Header("References")]
    Rigidbody2D rb;

    [Header("Distance for the Enemy to detect")]
    [SerializeField] float distanceToStop = 5f;
    [SerializeField] float distanceToShoot = 2f;

    [Header("Firing Rate for the enemy")]
    [SerializeField] float fireRate;
    [SerializeField] float timer = 0;
    [SerializeField] float timeToFire = 1f;
    [SerializeField] float nextFireRate;


    [Header("References for the gun")]
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = fireRate;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if(player == null)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }

        if(Vector2.Distance(transform.position, player.position) <= distanceToShoot)
        {
            Shoot();
        }
    }

    void GetTarget()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void RotateTowardsTarget()
    {
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(0,0,angle);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotationSpeed);
    }

    void Shoot()
    {
        if(timer < 0 && nextFireRate < Time.time)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            nextFireRate = Time.time + timeToFire;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if(Vector2.Distance(transform.position,player.position) <= distanceToStop)
        {
            rb.linearVelocity = transform.up * enemySpeed * Time.deltaTime;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}
