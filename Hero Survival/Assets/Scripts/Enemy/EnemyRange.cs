using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] float speed = 2f;
    [SerializeField] float lineOfSite = 5f;
    [SerializeField] Transform player;

    void Start()
    {
        if(player != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, player.position);
        if (distanceFromPlayer < lineOfSite)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}
