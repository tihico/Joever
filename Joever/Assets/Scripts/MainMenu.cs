using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayTheGame()
    {
        SceneManager.LoadSceneAsync("Game");
    }
    public void doExitGame()
    {
        Application.Quit();
    }
}
