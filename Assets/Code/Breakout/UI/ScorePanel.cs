using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;
    public TMP_Text HighScoreText { get => highScoreText; set => highScoreText = value; }
    
    [SerializeField] private TMP_Text currentScoreText;
    public TMP_Text CurrentScoreText { get => currentScoreText; set => currentScoreText = value; }
    
    [SerializeField] private TMP_Text hitPointsText;

    public void SetCurrentScore(int value)
    {
        currentScoreText.text = "Current Score " + value;
    }
    public void SetHighScore(int value)
    {
        highScoreText.text = "Mode High Score " + value;
    }
    public void SetHitPoints(int value)
    {
        hitPointsText.text = "Ball Count " + value;
    }
}
