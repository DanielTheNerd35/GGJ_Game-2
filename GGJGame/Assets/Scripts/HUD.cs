using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Slider healthbar;
    private int maxHealth;

   private void SetupHealthbar(GameObject player)
   {
        healthbar.value = healthbar.maxValue;
        maxHealth = player.GetComponent<PlayerHealth>().maxHealth;
   }

   private void UpdateHealthbar(int currentHealth)
   {
        healthbar.value = (float)currentHealth / maxHealth;
        healthbar.value = Mathf.Clamp01(healthbar.value);
   }

   private void OnEnable()
   {
        GameManager.OnPlayerSpawned += SetupHealthbar;
        PlayerHealth.OnPlayerTakeDamage += UpdateHealthbar;
   }

   private void OnDisable()
   {
        GameManager.OnPlayerSpawned -= SetupHealthbar;
        PlayerHealth.OnPlayerTakeDamage -= UpdateHealthbar;
   }
}
