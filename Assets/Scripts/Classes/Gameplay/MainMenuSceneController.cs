using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneController : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
