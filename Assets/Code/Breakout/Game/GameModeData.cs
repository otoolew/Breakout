using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Breakout/Game Mode Data", fileName = "newGameMode")]
public class GameModeData : ScriptableObject
{
    [SerializeField, TextArea] private string gameModeDescription;
    public string GameModeDescription { get => gameModeDescription; set => gameModeDescription = value; }

    [SerializeField] private MatchState matchState;
    public MatchState MatchState { get => matchState; set => matchState = value; }
    
    [SerializeField] private Bumper bumperPrefab;
    public Bumper BumperPrefab { get => bumperPrefab; set => bumperPrefab = value; }
    
    [SerializeField] private Ball ballPrefab;
    public Ball BallPrefab { get => ballPrefab; set => ballPrefab = value; }

    [SerializeField] private Bounds bounds;
    public Bounds Bounds { get => bounds; set => bounds = value; }

    public void SetUpMatch()
    {
        matchState = MatchState.SERVING;
        Bumper bumper =  Instantiate(bumperPrefab, Vector3.zero, Quaternion.identity);
        Ball ball = Instantiate(ballPrefab, Vector3.up, Quaternion.identity);
        ball.Bounds = bounds;
        // InstructionPanel instructionPanel = Instantiate(instructionPanelPrefab);
        // instructionPanel.onClosePanel += OnInstructionPanelClose;
        
    }
    IEnumerator EnterServeState(Ball ball)
    {
        Debug.Log("Server State");
        while (matchState == MatchState.SERVING)
        {
            yield return null;
        }
        
        yield return null;
    }
}
