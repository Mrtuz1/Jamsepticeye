using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;      // Maksimum can
    private int currentHealth;       // Mevcut can

    void Start()
    {
        currentHealth = maxHealth;   // Oyuna baþlarken maksimum can
    }

    /// <summary>
    /// Bu fonksiyon çaðrýldýðýnda can azalýr
    /// </summary>
    /// <param name="damageAmount">Alýnacak hasar miktarý</param>
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Max(currentHealth, 0); // Can 0 altýna düþmesin

        Debug.Log(gameObject.name + " hasar aldý! Kalan can: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Can bittiðinde yapýlacaklar
    /// </summary>
    private void Die()
    {
        Debug.Log(gameObject.name + " yok oldu!");
        // Burada efekt, animasyon, skor artýþý gibi iþlemler yapýlabilir
        Destroy(gameObject);
    }

    /// <summary>
    /// Mevcut caný baþka yerlerden almak için
    /// </summary>
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    /// <summary>
    /// Caný arttýrmak istersen (opsiyonel)
    /// </summary>
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        Debug.Log(gameObject.name + " iyileþti! Yeni can: " + currentHealth);
    }
}
