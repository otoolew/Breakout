using System;
using System.Collections;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Serialization;

//[CreateAssetMenu(menuName = "Breakout/GameMode", fileName = "newGameMode")]
public class GameMode : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    public GameState GameState { get => gameState; set => gameState = value; }
    
    [SerializeField] private MainCanvas mainCanvas;
    public MainCanvas MainCanvas { get => mainCanvas; set => mainCanvas = value; }
    
    [SerializeField, TextArea] private string gameModeDescription;
    public string GameModeDescription { get => gameModeDescription; set => gameModeDescription = value; }

    [SerializeField] private MatchState matchState;
    public MatchState MatchState { get => matchState; set => matchState = value; }
    
    [SerializeField] private Bumper bumper;
    public Bumper Bumper { get => bumper; set => bumper = value; }
    
    [SerializeField] private Ball ball;
    public Ball BallPrefab { get => ball; set => ball = value; }

    [SerializeField] private LineRenderer borderline;
    public LineRenderer Borderline { get => borderline; set => borderline = value; }
    
    [SerializeField] private Bounds bounds;
    public Bounds Bounds { get => bounds; set => bounds = value; }
    
    public void SetUpMatch(GameModeData gameModeData)
    {
        borderline.SetPositions(bounds.BoundingBox);
        matchState = MatchState.SERVING;
        bumper =  Instantiate(gameModeData.BumperPrefab, Vector3.up, Quaternion.identity);
        ball = Instantiate(gameModeData.BallPrefab, bumper.transform.position += Vector3.up, Quaternion.identity);
        ball.Bounds = gameModeData.Bounds;
    }
    
    #region Debugging -------------------------------------------------------------------------------------------------
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector2(bounds.XMin,bounds.YMin),new Vector2(bounds.XMax,bounds.YMin)); // 0-1
        Gizmos.DrawLine(new Vector2(bounds.XMax,bounds.YMin),new Vector2(bounds.XMax,bounds.YMax)); // 1-2
        Gizmos.DrawLine(new Vector2(bounds.XMax,bounds.YMax),new Vector2(bounds.XMin,bounds.YMax)); // 2-3
        Gizmos.DrawLine(new Vector2(bounds.XMin,bounds.YMax),new Vector2(bounds.XMin,bounds.YMin)); // 3-4
    }
    #endregion
}
