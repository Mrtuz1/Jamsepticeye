using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;      // Maksimum can
    private int currentHealth;       // Mevcut can

    void Start()
    {
        currentHealth = maxHealth;   // Oyuna ba�larken maksimum can
    }

    /// <summary>
    /// Bu fonksiyon �a�r�ld���nda can azal�r
    /// </summary>
    /// <param name="damageAmount">Al�nacak hasar miktar�</param>
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Max(currentHealth, 0); // Can 0 alt�na d��mesin

        Debug.Log(gameObject.name + " hasar ald�! Kalan can: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Can bitti�inde yap�lacaklar
    /// </summary>
    private void Die()
    {
        Debug.Log(gameObject.name + " yok oldu!");
        // Burada efekt, animasyon, skor art��� gibi i�lemler yap�labilir
        Destroy(gameObject);
    }

    /// <summary>
    /// Mevcut can� ba�ka yerlerden almak i�in
    /// </summary>
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    /// <summary>
    /// Can� artt�rmak istersen (opsiyonel)
    /// </summary>
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        Debug.Log(gameObject.name + " iyile�ti! Yeni can: " + currentHealth);
    }
}
