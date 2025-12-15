using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
   
    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100;

        if(healthAmount <=0)
        {
            healthAmount = 0;
            UIManager.instance.GameOver();
            gameObject.SetActive(false);
        }
    }
}