using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        // Her frame düþmaný aþaðýya indir
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // Eðer ekranýn altýna inerse yok et
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Eðer mermiye çarparsa yok et
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject); // Mermiyi yok et
            Destroy(gameObject); // Düþmaný yok et
        }
    }
}
