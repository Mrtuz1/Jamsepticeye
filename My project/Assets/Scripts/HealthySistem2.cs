using System.Collections;
using UnityEngine;
using UnityEngine.UI; // UI g�stergesi kullanacaksan gerekli

public class PlayerHealth : MonoBehaviour
{
    [Header("Can Ayarlar�")]
    public float maxHealth = 100f;       // Maksimum can
    [HideInInspector] public float currentHealth;

    [Header("�arp��ma Korumas�")]
    public float invulnTime = 0.8f;      // �arp��madan sonra dokunulmazl�k s�resi
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
        // E�er zaten koruma aktifse veya d��man de�ilse ��k
        if (isInvulnerable || !other.CompareTag("Enemy")) return;

        // Mevcut can� yar�ya d���r
        currentHealth *= 0.5f;
        if (currentHealth < 0) currentHealth = 0;

        UpdateUI();

        // K�sa s�reli koruma ba�lat
        StartCoroutine(InvulnerabilityCoroutine());

        // Can s�f�rland�ysa �l
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    IEnumerator InvulnerabilityCoroutine()
    {
        isInvulnerable = true;

        // (Opsiyonel) G�rsel olarak yan�p s�nme efekti
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
        Debug.Log("Oyuncu �ld�!");
        // Buraya oyun bitirme, sahne yenileme vs. ekleyebilirsin.
        // �rnek:
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
