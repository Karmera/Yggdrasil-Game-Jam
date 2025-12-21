using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHearts = 3;
    public int currentHearts;

    void Start()
    {
        ResetHearts();
    }

    public void ResetHearts()
    {
        currentHearts = maxHearts;
        Debug.Log("Hearts refilled");
    }

    public void LoseHeart()
    {
        currentHearts--;

        Debug.Log("Heart lost. Remaining: " + currentHearts);

        if (currentHearts <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        FindObjectOfType<GameOverUI>().ShowGameOver();
        gameObject.SetActive(false); // disable player
    }
}
