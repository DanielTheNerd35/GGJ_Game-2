using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int currentHealth {get; private set;}
    public int maxHealth {get; private set;}
    public static Action<int> OnPlayerTakeDamage;
    public static Action OnPlayerDie;

    void Awake()
    {
        currentHealth = health;
        maxHealth = health;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        OnPlayerTakeDamage?.Invoke(currentHealth);
        Debug.Log("Took Damage!");
        if (currentHealth <= 0)
        {
            OnPlayerDie.Invoke();
            Destroy(gameObject);
        }
    }

}
