using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Breakout Classic Game Mode
/// </summary>
[CreateAssetMenu(menuName = "Breakout/Game Mode Data/Classic Mode", fileName = "ClassicMode")]
public class ClassicGameMode : GameModeData
{
    #region Fields and Properties -------------------------------------------------------------------------------------
    /// <summary>
    /// The Scene Info that this Game Mode uses to load its scene
    /// </summary>
    [SerializeField] private SceneInfo sceneInfo;
    public override SceneInfo SceneInfo { get => sceneInfo; set => sceneInfo = value; }
    
    /// <summary>
    /// Description of the game mode
    /// </summary>
    [SerializeField, TextArea] private string gameModeDescription;
    public override string GameModeDescription { get => gameModeDescription; set => gameModeDescription = value; }
    
    [SerializeField] private Brick brickPrefab;
    public override Brick BrickPrefab { get => brickPrefab; set => brickPrefab = value; }
    
    /// <summary>
    /// The gameplay bounds
    /// </summary>
    [SerializeField] private Bounds bounds;
    public override Bounds Bounds { get => bounds; set => bounds = value; }
    
    /// <summary>
    /// Stores the high score for this game Mode
    /// </summary>
    [SerializeField] private int highScore;
    public override int HighScore { get => highScore; set => highScore = value; }
    
    /// <summary>
    /// Number of balls the player can lose.
    /// </summary>
    [SerializeField] private int ballLimit;
    #endregion
    
    /// <summary>
    /// Sets the Match up for classic play.
    /// </summary>
    /// <param name="game"></param>
    public override void SetUpMatch(GameMode game)
    {
        base.SetUpMatch(game);
        game.HitPoints = ballLimit; // Sets hit points to ball limit.
        game.MainCanvas.ScorePanel.SetHitPoints(ballLimit); // Updates hit points UI
        game.Ball.ResetToStartPosition();
        game.ServeBall();
    }
    
    /// <summary>
    /// Resets the game ball and updates balls remaining.
    /// </summary>
    /// <param name="game"></param>
    public override void ResetMatch(GameMode game)
    {
        base.ResetMatch(game);
        game.HitPoints -= 1;
        game.MainCanvas.ScorePanel.SetHitPoints(game.HitPoints);
        
        if (game.HitPoints > 0)
        {
            game.Ball.ResetToStartPosition();
            game.Ball.ResetDirection();
            game.ServeBall();
        }
        else
        {
            game.Ball.ResetToStartPosition();
            game.MainCanvas.SetGameLostMenuActive(true);
        }
    }
    
}
