using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndSceneManager : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI timeText;
    public GameObject exitButton;
    public GameObject restartButton;

    void Start()
    {
        string gameResult = PlayerPrefs.GetString("GameResult");
        int elapsedTimeInt = PlayerPrefs.GetInt("ElapsedTime");

        resultText.text = gameResult;
        timeText.text = elapsedTimeInt.ToString() + " s";

        exitButton.SetActive(true);
        restartButton.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("A4");
    }
}