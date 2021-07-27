using System;
using System.Collections;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

//[CreateAssetMenu(menuName = "Breakout/GameMode", fileName = "newGameMode")]
public class GameMode : MonoBehaviour
{
    [SerializeField] private GameModeData gameModeData;
    public GameModeData GameModeData { get => gameModeData; set => gameModeData = value; }
    
    [SerializeField] private GameState gameState;
    public GameState GameState { get => gameState; set => gameState = value; }
    
    [SerializeField] private MainCanvas mainCanvas;
    public MainCanvas MainCanvas { get => mainCanvas; set => mainCanvas = value; }

    [SerializeField] private Bumper bumper;
    public Bumper Bumper { get => bumper; set => bumper = value; }
    
    [SerializeField] private Ball ball;
    public Ball Ball { get => ball; set => ball = value; }

    [SerializeField] private LineRenderer borderline;
    public LineRenderer Borderline { get => borderline; set => borderline = value; }

    [SerializeField] private int currentScore;
    public int CurrentScore { get => currentScore; set => currentScore = value; }
    
    [SerializeField] private int hitPoints;
    public int HitPoints { get => hitPoints; set => hitPoints = value; }

    private void Start()
    {
        mainCanvas.ScorePanel.SetHighScore(gameModeData.HighScore);
        SetUpMatch();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    
    public void SetUpMatch()
    {
        gameModeData.SetUpMatch(this);
    }
    
    public void ResetMatch()
    {
        gameModeData.ResetMatch(this);
    }
    
    public void AddScoreValue(int value)
    {
        currentScore += value;
        mainCanvas.ScorePanel.SetCurrentScore(currentScore);
        
        if (currentScore > gameModeData.HighScore)
        {
            gameModeData.HighScore = currentScore;
            mainCanvas.ScorePanel.SetHighScore(currentScore);
        }
        
        if (gameObject.transform.childCount == 0)
        {
            
        }        
    }
    
    #region Game State ------------------------------------------------------------------------------------------------
    /// <summary>
    /// Pauses the game.
    /// </summary>
    public void PauseGame()
    {
        if (gameState == GameState.PAUSED)
        {
            mainCanvas.SetPauseMenuActive(false);
            gameState = GameState.RUNNING;
            Time.timeScale = 1.0f;
        }
        else
        {
            mainCanvas.SetPauseMenuActive(true);
            gameState = GameState.PAUSED;
            Time.timeScale = 0.0f;
        }
    }
    #endregion
    
    #region Debugging -------------------------------------------------------------------------------------------------
    private void OnDrawGizmos()
    {
        if (gameModeData == null)
        {
            Debug.LogError("OnDrawGizmos GameMode needs Data");
            return;
        }
        
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector2(gameModeData.Bounds.XMin,gameModeData.Bounds.YMin),
            new Vector2(gameModeData.Bounds.XMax,gameModeData.Bounds.YMin)); // 0-1
        Gizmos.DrawLine(new Vector2(gameModeData.Bounds.XMax,gameModeData.Bounds.YMin),
            new Vector2(gameModeData.Bounds.XMax,gameModeData.Bounds.YMax)); // 1-2
        Gizmos.DrawLine(new Vector2(gameModeData.Bounds.XMax,gameModeData.Bounds.YMax),
            new Vector2(gameModeData.Bounds.XMin,gameModeData.Bounds.YMax)); // 2-3
        Gizmos.DrawLine(new Vector2(gameModeData.Bounds.XMin,gameModeData.Bounds.YMax),
            new Vector2(gameModeData.Bounds.XMin,gameModeData.Bounds.YMin)); // 3-4
    }
    
    private void OnValidate()
    {
        if (gameModeData == null)
        {
            Debug.LogError("OnValidate GameMode needs Data to initialize");
            return;
        }
        
        if (borderline == null)
        {
            borderline = GetComponent<LineRenderer>();
        }
 
        borderline.SetPositions(gameModeData.Bounds.BoundingBox);
    }

    #endregion
}
