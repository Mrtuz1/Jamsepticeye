using UnityEngine;

public class CharController : MonoBehaviour
{
    public float moveSpeed = 5f;          // Karakterin hareket hızı
    public GameObject bulletPrefab;       // Ateşlenecek mermi prefab'ı
    public float bulletSpeed = 10f;       // Mermi hızı

    private Rigidbody2D rb;
    private float moveInput;

    [SerializeField] private Transform[] firePoints; // Birden fazla fire point

    // Eklenen kısım: X sınırları
    private float minX = -8f;
    private float maxX = 8f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Hareket girişi
        moveInput = 0;
        if (Input.GetKey(KeyCode.A))
            moveInput = -1;
        if (Input.GetKey(KeyCode.D))
            moveInput = 1;

        // Ateşleme
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        // Karakteri hareket ettir
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Eklenen kısım: X pozisyonunu sınırla
        Vector2 clampedPos = rb.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, minX, maxX);
        rb.position = clampedPos;
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoints.Length > 0)
        {
            foreach (Transform firePoint in firePoints)
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                if (bulletRb != null)
                {
                    bulletRb.linearVelocity = firePoint.up * bulletSpeed;
                }
            }
        }
    }
}
