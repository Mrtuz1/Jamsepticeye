using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("H�z Ayarlar�")]
    public float baseSpeed = 2f;               // Ba�lang�� h�z�
    public float speedIncreaseRate = 0.5f;     // Zamanla art�� oran� (logaritmik �arpan)
    public float maxSpeed = 4f;                // Maksimum h�z limiti

    void Update()
    {
        // Logaritmik olarak zamanla artan h�z
        float currentSpeed = baseSpeed + Mathf.Log(Time.time + 1) * speedIncreaseRate;

        // Maksimum h�z� ge�mesin
        currentSpeed = Mathf.Min(currentSpeed, maxSpeed);

        // D��man� a�a��ya hareket ettir
        transform.Translate(Vector2.down * currentSpeed * Time.deltaTime);

        // Ekran�n alt�na d��erse yok et
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // E�er �arpan obje "Bullet" tag'ine sahipse:
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject); // Mermiyi yok et
            Destroy(gameObject);           // D��man� yok et


        }
    }
}
