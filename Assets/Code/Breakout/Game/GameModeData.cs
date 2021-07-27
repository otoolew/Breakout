using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Abstract GameModeData used as a base to create other game modes.
/// </summary>
public abstract class GameModeData : ScriptableObject
{
    /// <summary>
    /// SceneInfo stores information GameModeData will use to load the correct scene
    /// </summary>
    public abstract SceneInfo SceneInfo { get; set; }
    
    /// <summary>
    /// Description of the Game Mode
    /// </summary>
    public abstract string GameModeDescription { get; set; }

    /// <summary>
    /// Brick Prefab to Instance
    /// </summary>
    public abstract Brick BrickPrefab { get; set; }
    
    /// <summary>
    /// The gameplay bounds
    /// </summary>
    public abstract Bounds Bounds { get; set; }
    
    /// <summary>
    /// Stores the high score for this game Mode
    /// </summary>
    public abstract int HighScore {  get; set; }
    
    /// <summary>
    /// Sets up match for gameplay.
    /// </summary>
    /// <param name="game"></param>
    public virtual void SetUpMatch(GameMode game)
    {
        game.Borderline.SetPositions(Bounds.BoundingBox);
        game.Bumper.Bounds = Bounds;
        
        game.Ball.Bounds = Bounds;
        game.Ball.BallOutOfBounds = game.ResetMatch;
        game.Ball.ResetToStartPosition();
        
        game.CurrentScore = 0;
        game.MainCanvas.ScorePanel.SetCurrentScore(0);
        game.MainCanvas.ScorePanel.SetHighScore(HighScore);
        
        game.ServeBall();
    }

    /// <summary>
    /// Resets the game ball and updates balls remaining.
    /// </summary>
    /// <param name="game"></param>
    public virtual void ResetMatch(GameMode game)
    {
        game.Bumper.ResetToStartPosition();
        game.Ball.ResetToStartPosition();
    }
    /// <summary>
    /// Resets the game ball and updates balls remaining.
    /// </summary>
    /// <param name="game"></param>
    public virtual void AdvanceMatch(GameMode game)
    {
        game.Bumper.ResetToStartPosition();
        game.Ball.ResetToStartPosition();
    }
}
