using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
/// <summary>
/// The Monobehaviour that runs the GameModeData
/// </summary>
public class GameMode : MonoBehaviour
{
    #region Fields and Properties -------------------------------------------------------------------------------------
    [SerializeField] private GameModeData gameModeData;
    /// <summary>
    /// The Game Mode Data that will be loaded for this scene.
    /// </summary>
    public GameModeData GameModeData { get => gameModeData; set => gameModeData = value; }
    
    [SerializeField] private GameState gameState;
    /// <summary>
    /// The Game's current state.
    /// </summary>
    public GameState GameState { get => gameState; set => gameState = value; }
    
    [SerializeField] private MainCanvas mainCanvas;
    /// <summary>
    /// The main canvas used to display UI game information.
    /// </summary>
    public MainCanvas MainCanvas { get => mainCanvas; set => mainCanvas = value; }

    [SerializeField] private Bumper bumper;
    /// <summary>
    /// Player controls this bumper
    /// </summary>
    public Bumper Bumper { get => bumper; set => bumper = value; }
    
    [SerializeField] private Ball ball;
    /// <summary>
    /// The Game Ball
    /// </summary>
    public Ball Ball { get => ball; set => ball = value; }

    [SerializeField] private LineRenderer borderline;
    /// <summary>
    /// LineRender Comp Draws the gameplay bounds.
    /// </summary>
    public LineRenderer Borderline { get => borderline; set => borderline = value; }

    [SerializeField] private int currentScore;
    /// <summary>
    /// The current game score.
    /// </summary>
    public int CurrentScore { get => currentScore; set => currentScore = value; }
    
    [SerializeField] private int hitPoints;
    /// <summary>
    /// The number of tries a player has left
    /// </summary>
    public int HitPoints { get => hitPoints; set => hitPoints = value; }
    
    [SerializeField] private int bricksRemaining;
    public int BricksRemaining { get => bricksRemaining; set => bricksRemaining = value; }
    
    [SerializeField] private Vector2[] brickPositions;
    public Vector2[] BrickPositions { get => brickPositions; set => brickPositions = value; }
    #endregion

    #region Monobehaviour ---------------------------------------------------------------------------------------------
    private void Start()
    {
        Brick[] bricks = FindObjectsOfType<Brick>();
        brickPositions = new Vector2[bricks.Length];
        for (int i = 0; i < bricks.Length; i++)
        {
            brickPositions[i] = bricks[i].transform.position;
        }
        bricksRemaining = bricks.Length;
        mainCanvas.ScorePanel.SetHighScore(gameModeData.HighScore); // set the High Score
        SetUpMatch(); // Set Up the Match
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Check for Player Pause Input.
        {
            PauseGame();
        }
    }
    #endregion

    #region GameMode 
    /// <summary>
    /// Sets up the game via GameMode
    /// </summary>
    public void SetUpMatch()
    {
        gameModeData.SetUpMatch(this);
    }
    
    /// <summary>
    /// Resets the Match via GameMode
    /// </summary>
    public void ResetMatch()
    {
        gameModeData.ResetMatch(this);

    }
    /// <summary>
    /// Serve Ball
    /// </summary>
    public void ServeBall()
    {
        StartCoroutine(DelayedBallServe());
    }
    /// <summary>
    /// Serves the ball after a one second delay.
    /// </summary>
    /// <param name="game"></param>
    /// <returns></returns>
    private IEnumerator DelayedBallServe()
    {
        yield return new WaitForSeconds(1);
        Ball.Move(Vector2.up + Vector2.right);
    }
    /// <summary>
    /// Handles adding points to the score UI and checking win lose condition
    /// </summary>
    /// <param name="value"></param>
    public void AddScoreValue(int value)
    {
        currentScore += value;
        mainCanvas.ScorePanel.SetCurrentScore(currentScore);
        
        if (currentScore > gameModeData.HighScore)
        {
            gameModeData.HighScore = currentScore;
            mainCanvas.ScorePanel.SetHighScore(currentScore);
        }

        if (transform.childCount <= 1)
        {
            ResetMatch();
            for (int i = 0; i < brickPositions.Length; i++)
            {
                Instantiate(gameModeData.BrickPrefab,brickPositions[i], Quaternion.identity, transform);
            }
        }
    
    }
    #endregion

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
 
        borderline.SetPositions(gameModeData.Bounds.BoundingBox); // Update the LineRenderer to display the bounds.
    }

    #endregion
}
