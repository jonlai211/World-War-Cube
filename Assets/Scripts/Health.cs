using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public UnityEvent onDamageTaken;
    public UnityEvent onDeath;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        onDamageTaken.Invoke();

        if (currentHealth <= 0)
        {
            onDeath.Invoke();
            currentHealth = 0;
            Debug.Log(gameObject.name + " has died.");
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        onDamageTaken.Invoke();
    }
}