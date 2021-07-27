using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    public GameObject PauseMenu { get => pauseMenu; set => pauseMenu = value; }
    
    [SerializeField] private GameObject gameWonMenu;
    public GameObject GameWonMenu { get => gameWonMenu; set => gameWonMenu = value; }
    
    [SerializeField] private GameObject gameLostMenu;
    public GameObject GameLostMenu { get => gameLostMenu; set => gameLostMenu = value; }
    
    [SerializeField] private ScorePanel scorePanel;
    public ScorePanel ScorePanel { get => scorePanel; set => scorePanel = value; }
    
    public void SetPauseMenuActive(bool value)
    {
        pauseMenu.SetActive(value);
    }
    public void SetGameWonMenuActive(bool value)
    {
        gameWonMenu.SetActive(value);
    }
    public void SetGameLostMenuActive(bool value)
    {
        gameLostMenu.SetActive(value);
    }
}
