using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Breakout/Game Mode Data/Endless Mode", fileName = "EndlessMode")]
public class EndlessGameMode : GameModeData
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
    
    public override void SetUpMatch(GameMode game)
    {
        base.SetUpMatch(game);
    }
    
    public override void ResetMatch(GameMode game)
    {
        base.ResetMatch(game);
        game.StartCoroutine(DelayedReset(game));
    }
    
    IEnumerator DelayedReset(GameMode game)
    {
        yield return new WaitForSeconds(1);
        game.Ball.Move(Vector2.up + Vector2.right);
    }
}
