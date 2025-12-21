using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    //Door Settings
    public string nextLevelName = "Room 1";  // Set in Inspector
    public Animator doorAnimator;            // Optional door animation
    public AudioSource openSound;            // Optional sound effect
    
    //Debug
    public bool isBreathingInRange = false;

    private bool playerInRange = false;
    private bool levelLoaded = false;

    void Update()
    {
        // Check breathing only when player is in range
        if (playerInRange && BreathingController.IsBreathing && !levelLoaded)
        {
            isBreathingInRange = true;
            OpenDoorAndLoadLevel();
        }
        else
        {
            isBreathingInRange = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player entered door range");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player left door range");
        }
    }

    void OpenDoorAndLoadLevel()
    {
        levelLoaded = true; // Prevent multiple loads
        
        // Play door opening animation (if assigned)
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Open");
        }
        
        // Play sound (if assigned)
        if (openSound != null)
        {
            openSound.Play();
        }
        
        Debug.Log("Door opening! Loading: " + nextLevelName);
        
        // Load next level after short delay
        Invoke("LoadNextLevel", 0.5f);
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }
}
