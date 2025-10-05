using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Hýz Ayarlarý")]
    public float baseSpeed = 2f;               // Baþlangýç hýzý
    public float speedIncreaseRate = 0.5f;     // Zamanla artýþ oraný (logaritmik çarpan)
    public float maxSpeed = 4f;                // Maksimum hýz limiti

    void Update()
    {
        // Logaritmik olarak zamanla artan hýz
        float currentSpeed = baseSpeed + Mathf.Log(Time.time + 1) * speedIncreaseRate;

        // Maksimum hýzý geçmesin
        currentSpeed = Mathf.Min(currentSpeed, maxSpeed);

        // Düþmaný aþaðýya hareket ettir
        transform.Translate(Vector2.down * currentSpeed * Time.deltaTime);

        // Ekranýn altýna düþerse yok et
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Eðer çarpan obje "Bullet" tag'ine sahipse:
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject); // Mermiyi yok et
            Destroy(gameObject);           // Düþmaný yok et


        }
    }
}
