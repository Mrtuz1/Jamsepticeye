using UnityEngine;

public class JetCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Jet düþmana çarptý! Jet yok oldu!");
            Destroy(gameObject); // Jet'i yok eder
        }
    }
}
