using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public int Minutes;

    private int totalSeconds;
    private float timer = 0f;
    private bool isRunning = false;

    void Start() 
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "Level1")
            Minutes = 1;
        else if (sceneName == "Level2")
            Minutes = 3;
        totalSeconds = Minutes * 60;
        UpdateTimerDisplay();
        timerText.enabled = false;
        StartTimer();
    }

    public void StartTimer()
    {
        totalSeconds = Minutes * 60;
        isRunning = true;
        timer = 0f;
        timerText.enabled = true;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (!isRunning) 
            return;
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            timer = 0f;
            totalSeconds--;
            if (totalSeconds <= 0) {
                totalSeconds = 0;
                isRunning = false;

                GameOverController.Show = true;
            }
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        int Minutes = totalSeconds / 60;
        int Seconds = totalSeconds % 60;
        timerText.text = Minutes.ToString("D2") + ":" + Seconds.ToString("D2");
    }
}