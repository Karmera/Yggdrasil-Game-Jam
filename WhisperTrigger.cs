using UnityEngine;
using TMPro;
using System.Collections;

public class WhisperTrigger : MonoBehaviour
{
    public string whisperLine;
    public TextMeshProUGUI whisperText;
    public float fadeDuration = 1f;
    public float stayDuration = 2f;

    private bool triggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            StartCoroutine(ShowWhisper());
        }
    }

    IEnumerator ShowWhisper()
    {
        whisperText.text = whisperLine;

        // Fade In
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            whisperText.alpha = t / fadeDuration;
            yield return null;
        }

        whisperText.alpha = 1;
        yield return new WaitForSeconds(stayDuration);

        // Fade Out
        for (float t = fadeDuration; t > 0; t -= Time.deltaTime)
        {
            whisperText.alpha = t / fadeDuration;
            yield return null;
        }

        whisperText.alpha = 0;
    }
}
