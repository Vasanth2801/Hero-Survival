using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] float speed = 7f;
    Rigidbody2D rb;

    [Header("Bullet Timings")]
    [SerializeField] float lifeOfBullet = 4f;
    float timer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        timer = lifeOfBullet;
        if(rb != null)
        {
            rb.linearVelocity = transform.up * speed;
        }
    }


    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
