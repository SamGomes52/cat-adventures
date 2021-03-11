using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour
{

    public int totalScore;
    public Text scoreText;

    public GameObject gameOver;
    public GameObject checkMessage;
    public GameObject checkMessageWin;

    public static GameControler instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString() + " /15";
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void ShowCheckMessage()
    {
        checkMessage.SetActive(true);
    }
    public void HideCheckMessage()
    {
        checkMessage.SetActive(false);
    }

    public void ShowCheckMessageWin()
    {
        checkMessageWin.SetActive(true);
    }
    public void HideCheckMessageWin()
    {
        checkMessageWin.SetActive(false);
    }

    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }
}