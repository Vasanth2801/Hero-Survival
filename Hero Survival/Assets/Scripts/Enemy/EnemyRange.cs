using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] float speed = 2f;
    [SerializeField] float lineOfSite = 5f;
    [SerializeField] float shootingRange;

    [Header("References")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject firePoint;
    [SerializeField] Transform player;

    [Header("Shooting Settings")]
    [SerializeField] float fireRate = 1f;
    [SerializeField] float nextFireRate;

    void Start()
    {
        if(player != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if(distanceFromPlayer <= shootingRange && nextFireRate < Time.time)
        {
            Instantiate(bulletPrefab,firePoint.transform.position,Quaternion.identity);
            nextFireRate = Time.time + fireRate;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}