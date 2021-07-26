using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    [SerializeField] private Score highScore;
    public Score HighScore { get => highScore; set => highScore = value; }
    
    [SerializeField] private GameObject pauseMenu;
    public GameObject PauseMenu { get => pauseMenu; set => pauseMenu = value; }
    
    [SerializeField] private ScorePanel scorePanel;
    public ScorePanel ScorePanel { get => scorePanel; set => scorePanel = value; }
    
    public void SetPauseMenuActive(bool value)
    {
        pauseMenu.SetActive(value);
    }

    public void SetHighScore(int value)
    {
        scorePanel.HighScoreText.text = highScore.Value.ToString();
    }
}
