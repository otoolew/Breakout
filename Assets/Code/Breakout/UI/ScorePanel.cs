using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;
    public TMP_Text HighScoreText { get => highScoreText; set => highScoreText = value; }
    
    [SerializeField] private TMP_Text currentScore;
    public TMP_Text CurrentScore { get => currentScore; set => currentScore = value; }
    
    public void UpdateCurrentScore(int value)
    {
        highScoreText.text = "Current Score " + value;
    }
    
    public void UpdateHighScore(int value)
    {
        highScoreText.text = "High Score " + value;
    }
}
