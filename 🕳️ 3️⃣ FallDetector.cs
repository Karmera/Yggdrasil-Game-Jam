using UnityEngine;

public class FallDetector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.LoseHeart();
            }

            // Respawn player at last safe position
            other.transform.position = Vector3.zero;
        }
    }
}
