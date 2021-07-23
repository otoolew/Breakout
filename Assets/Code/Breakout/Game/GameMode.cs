using System.Collections;
using UnityEngine;


//[CreateAssetMenu(menuName = "Breakout/GameMode", fileName = "newGameMode")]
public class GameMode : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    public GameState GameState { get => gameState; set => gameState = value; }
    
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
    }

    IEnumerator EnterServeState()
    {
        Debug.Log("Server State");
        while (matchState == MatchState.SERVING)
        {
            yield return null;
        }
        
        yield return null;
    }
}
