using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameModeData : ScriptableObject
{
    public abstract SceneInfo SceneInfo { get; set; }
    public abstract string GameModeDescription { get; set; }
    protected abstract Bumper BumperPrefab { get; set; }
    protected abstract Ball BallPrefab { get; set; }
    public abstract Bounds Bounds { get; set; }
    public abstract int HighScore {  get; set; }

    public virtual void SetUpMatch(GameMode game)
    {
        game.Borderline.SetPositions(Bounds.BoundingBox);
        game.Bumper =  Instantiate(BumperPrefab, Vector3.up, Quaternion.identity);
        game.Bumper.Bounds = Bounds;
        
        game.Ball = Instantiate(BallPrefab, game.Bumper.transform.position += Vector3.up, Quaternion.identity);
        game.Ball.Bounds = Bounds;
        game.Ball.BallOutOfBounds = game.ResetMatch;
        
        game.CurrentScore = 0;
        game.MainCanvas.ScorePanel.SetCurrentScore(0);
        game.MainCanvas.ScorePanel.SetHighScore(HighScore);
    }
    
    public virtual void ResetMatch(GameMode game)
    {
        game.Bumper.transform.position = Vector3.up;
        game.Ball.transform.position = game.Bumper.transform.position += Vector3.up;
    }
}
