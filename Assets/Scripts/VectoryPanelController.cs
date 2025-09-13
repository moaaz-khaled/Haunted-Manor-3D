using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryPanel : MonoBehaviour
{
    [SerializeField] public GameObject VectoryPannel;
    private GameController gameController;

    void Start() {
        gameController = FindAnyObjectByType<GameController>();
    }

    public void ShowPannel() {
        Time.timeScale = 0;
        VectoryPannel.SetActive(true);
    }

    public void NextGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings) 
        {
            VectoryPannel.SetActive(false);
            Time.timeScale = 1;
            SceneManager.LoadScene(nextSceneIndex);
        } 
        else {
            Debug.Log("No more levels available. Exiting game.");
            Application.Quit();
        }
    }

    public void Exit()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}
