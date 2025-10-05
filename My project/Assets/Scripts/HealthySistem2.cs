using System.Collections;
using UnityEngine;
using UnityEngine.UI; // UI göstergesi kullanacaksan gerekli

public class PlayerHealth : MonoBehaviour
{
    [Header("Can Ayarlarý")]
    public float maxHealth = 100f;       // Maksimum can
    [HideInInspector] public float currentHealth;

    [Header("Çarpýþma Korumasý")]
    public float invulnTime = 0.8f;      // Çarpýþmadan sonra dokunulmazlýk süresi
    private bool isInvulnerable = false;

    [Header("UI (opsiyonel)")]
    public Slider healthSlider;
    public Text healthText;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Eðer zaten koruma aktifse veya düþman deðilse çýk
        if (isInvulnerable || !other.CompareTag("Enemy")) return;

        // Mevcut caný yarýya düþür
        currentHealth *= 0.5f;
        if (currentHealth < 0) currentHealth = 0;

        UpdateUI();

        // Kýsa süreli koruma baþlat
        StartCoroutine(InvulnerabilityCoroutine());

        // Can sýfýrlandýysa öl
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    IEnumerator InvulnerabilityCoroutine()
    {
        isInvulnerable = true;

        // (Opsiyonel) Görsel olarak yanýp sönme efekti
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            for (int i = 0; i < 4; i++)
            {
                sr.enabled = false;
                yield return new WaitForSeconds(invulnTime / 8);
                sr.enabled = true;
                yield return new WaitForSeconds(invulnTime / 8);
            }
        }

        yield return new WaitForSeconds(invulnTime);
        isInvulnerable = false;
    }

    void UpdateUI()
    {
        if (healthSlider) healthSlider.value = currentHealth / maxHealth;
        if (healthText) healthText.text = Mathf.CeilToInt(currentHealth).ToString();
    }

    void Die()
    {
        Debug.Log("Oyuncu öldü!");
        // Buraya oyun bitirme, sahne yenileme vs. ekleyebilirsin.
        // Örnek:
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
