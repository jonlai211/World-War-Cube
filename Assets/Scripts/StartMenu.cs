using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("A4");
    }
    
    public void TrainMode()
    {
        SceneManager.LoadScene("Train");
    }
    
    public void BackHome()
    {
        SceneManager.LoadScene("Start");
    }

    public void ExitGame()
    {
        Application.Quit();
        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}