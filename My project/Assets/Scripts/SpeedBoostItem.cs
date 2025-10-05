using UnityEngine;

public class SpeedBoostItem : MonoBehaviour
{
    public float boostSpeed = 10f; // Boost sonrası hız

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CharController player = other.GetComponent<CharController>();
            if (player != null)
            {
                player.BoostSpeed(boostSpeed); // Hızı arttır
            }
            Destroy(gameObject); // Itemi yok et
        }
    }
}
