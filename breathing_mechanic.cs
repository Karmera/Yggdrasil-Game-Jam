using UnityEngine;

public class BreathingController : MonoBehaviour
{
    public KeyCode breatheKey = KeyCode.LeftShift;
    public float slowTimeScale = 0.4f;
    public float normalTimeScale = 1f;

    public static bool IsBreathing;

    void Update()
    {
        if (Input.GetKey(breatheKey))
        {
            IsBreathing = true;
            Time.timeScale = slowTimeScale;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        else
        {
            IsBreathing = false;
            Time.timeScale = normalTimeScale;
            Time.fixedDeltaTime = 0.02f;
        }
    }
}
