using UnityEngine;

public class RoomManager : MonoBehaviour
{
    private bool entered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !entered)
        {
            entered = true;

            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.ResetHearts();
            }

            Debug.Log("Entered room — hearts refilled");
        }
    }
}
