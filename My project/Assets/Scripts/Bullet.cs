using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float minY = -5f;
    private float maxY = 5f;

    void Update()
    {
        // Ekran dýþýnda kalan mermiyi yok et
        if (transform.position.y > maxY || transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }
}
