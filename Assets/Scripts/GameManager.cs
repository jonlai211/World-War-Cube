using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Health heroHealth;
    public Health bossHealth;
    public TextMeshProUGUI timeText;
    private float startTime;
    private bool gameEnded = false;

    void Start()
    {
        startTime = Time.time;
        
        heroHealth.onDeath.AddListener(OnHeroDeath);
        bossHealth.onDeath.AddListener(OnBossDeath);
    }

    private void Update()
    {
        if (!gameEnded)
        {
            float elapsedTime = Time.time - startTime;
            int elapsedTimeInt = Mathf.FloorToInt(elapsedTime);
            timeText.text = elapsedTimeInt.ToString() + " s";
        }
    }

    void OnHeroDeath()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            float elapsedTime = Time.time - startTime;
            int elapsedTimeInt = Mathf.FloorToInt(elapsedTime);
            EndGame("WHY SO WEAK", elapsedTimeInt);
        }
    }

    void OnBossDeath()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            float elapsedTime = Time.time - startTime;
            int elapsedTimeInt = Mathf.FloorToInt(elapsedTime);
            EndGame("FUIYOH VICTORY", elapsedTimeInt);
        }
    }

    void EndGame(string result, int elapsedTimeInt)
    {
        PlayerPrefs.SetString("GameResult", result);
        PlayerPrefs.SetInt("ElapsedTime", elapsedTimeInt);
        SceneManager.LoadScene("End");
    }
}