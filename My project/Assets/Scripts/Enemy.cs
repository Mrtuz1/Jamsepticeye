using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        // Her frame d��man� a�a��ya indir
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // E�er ekran�n alt�na inerse yok et
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // E�er mermiye �arparsa yok et
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject); // Mermiyi yok et
            Destroy(gameObject); // D��man� yok et
        }
    }
}
