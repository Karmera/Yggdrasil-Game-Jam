using UnityEngine;
using System.Collections;

public class FragilePlatform : MonoBehaviour
{
    public float collapseDelay = 0.8f;
    private bool playerOn = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOn = true;
            StartCoroutine(CheckCollapse());
        }
    }

    IEnumerator CheckCollapse()
    {
        yield return new WaitForSeconds(collapseDelay);

        if (playerOn && !BreathingController.IsBreathing)
        {
            gameObject.SetActive(false); // collapse
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            playerOn = false;
    }
}
