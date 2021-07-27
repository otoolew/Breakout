using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Breakout/Game Mode Data/Classic Mode", fileName = "ClassicMode")]
public class ClassicGameMode : GameModeData
{
    [SerializeField] private SceneInfo sceneInfo;
    public override SceneInfo SceneInfo { get => sceneInfo; set => sceneInfo = value; }
    
    [SerializeField, TextArea] private string gameModeDescription;
    public override string GameModeDescription { get => gameModeDescription; set => gameModeDescription = value; }

    [SerializeField] private Bumper bumperPrefab;
    protected override Bumper BumperPrefab { get => bumperPrefab; set => bumperPrefab = value; }
    
    [SerializeField] private Ball ballPrefab;
    protected override Ball BallPrefab { get => ballPrefab; set => ballPrefab = value; }

    [SerializeField] private Bounds bounds;
    public override Bounds Bounds { get => bounds; set => bounds = value; }

    [SerializeField] private int highScore;
    public override int HighScore { get => highScore; set => highScore = value; }
    
    [SerializeField] private int ballLimit;
    public int BallLimit { get => ballLimit; set => ballLimit = value; }
    
    public override void SetUpMatch(GameMode game)
    {
        base.SetUpMatch(game);
        game.HitPoints = ballLimit;
        game.MainCanvas.ScorePanel.SetHitPoints(ballLimit);
    }
    
    public override void ResetMatch(GameMode game)
    {
        base.ResetMatch(game);
        game.HitPoints -= 1;
        game.MainCanvas.ScorePanel.SetHitPoints(game.HitPoints);
        
        if (game.HitPoints > 0)
        {
            game.StartCoroutine(DelayedReset(game));
        }
        else
        {
            game.MainCanvas.SetGameLostMenuActive(true);
        }
    }

    private IEnumerator DelayedReset(GameMode game)
    {
        yield return new WaitForSeconds(1);
        game.Ball.Move(Vector2.up + Vector2.right);
    }
}
