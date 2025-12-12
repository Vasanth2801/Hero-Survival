using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;
    Rigidbody2D bulletRb;

    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 moveDir = (target.position - transform.position).normalized * speed;
        bulletRb.linearVelocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2f);
    }
}
