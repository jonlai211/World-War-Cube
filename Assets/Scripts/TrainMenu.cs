using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainMenu : MonoBehaviour
{
    public void ExitTrainMode()
    {
        SceneManager.LoadScene("Start");
    }
}
