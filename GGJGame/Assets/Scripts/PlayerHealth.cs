using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int currentHealth;
    public int maxHealth;

    void Awake()
    {
        currentHealth = health;
        maxHealth = health;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Took Damage!");
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
