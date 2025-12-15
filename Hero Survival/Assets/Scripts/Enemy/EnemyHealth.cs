using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Health")]
    [SerializeField] int maxHealth = 40;
    [SerializeField] int currentHealth;

    [Header("References")]
    [SerializeField] EnemySpawner spawner;

    private void Start()
    {
        currentHealth = maxHealth;

        spawner = FindObjectOfType<EnemySpawner>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            spawner.waves[spawner.currentWave].enemiesCount--;
        }
    }
}