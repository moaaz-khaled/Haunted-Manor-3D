using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{

    [SerializeField] GameObject GameOverPanel;
    
    public static bool Show;

    void Start() {
        Show = false;
    }   

    void Update()
    {
        if(Show){
            Invoke("ShowPannel" , 1f);
            AudioListener.pause = true;
        }
    }

    public void ShowPannel() {
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
    }


    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        GameOverPanel.SetActive(false);
        Show = false;
        AudioListener.pause = false;
    }

    public void Exit()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}