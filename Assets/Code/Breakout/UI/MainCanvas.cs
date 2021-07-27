using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Main Canvas used for displaying various menus.
/// </summary>
public class MainCanvas : MonoBehaviour
{
    #region Fields and Properties
    /// <summary>
    /// Pause Menu displays when the game is paused
    /// </summary>
    [SerializeField] private GameObject pauseMenu;
    /// <summary>
    /// Game Lost Menu displays when the game is paused
    /// </summary>
    [SerializeField] private GameObject gameLostMenu;
    

    [SerializeField] private ScorePanel scorePanel;
    /// <summary>
    /// Score Panel handles updating score UI
    /// </summary>
    public ScorePanel ScorePanel { get => scorePanel; set => scorePanel = value; }

    #endregion

    /// <summary>
    /// Sets the Pause Menu gameobject Active
    /// </summary>
    /// <param name="value"></param>
    public void SetPauseMenuActive(bool value)
    {
        pauseMenu.SetActive(value);
    }
    /// <summary>
    /// Sets the Game Lost Menu gameobject Active
    /// </summary>
    /// <param name="value"></param>
    public void SetGameLostMenuActive(bool value)
    {
        gameLostMenu.SetActive(value);
    }
}
