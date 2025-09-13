using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManu : MonoBehaviour
{
    [SerializeField] GameObject PasueMenuUI;
    private GameController gameController;
    [SerializeField] private AudioSource PauseSound;

    private bool isPause = false;

    void Start() {
        PasueMenuUI.SetActive(false);
        gameController = FindFirstObjectByType<GameController>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
            if(isPause)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        isPause = false;
        PasueMenuUI.SetActive(false);
        AudioListener.pause = false;

        PauseSound.enabled = false;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        isPause = true;
        PasueMenuUI.SetActive(true);
        AudioListener.pause = true;

        PauseSound.ignoreListenerPause = true;
        PauseSound.enabled = true;
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void Exit() {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}