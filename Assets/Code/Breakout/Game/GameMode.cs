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
    
    // [SerializeField] private MainCanvas mainCanvas;
    // public MainCanvas MainCanvas { get => mainCanvas; set => mainCanvas = value; }

    [SerializeField] private Bumper bumper;
    public Bumper Bumper { get => bumper; set => bumper = value; }
    
    [SerializeField] private Ball ball;
    public Ball BallPrefab { get => ball; set => ball = value; }

    [SerializeField] private LineRenderer borderline;
    public LineRenderer Borderline { get => borderline; set => borderline = value; }

    [SerializeField] private int currentScore;
    public int CurrentScore { get => currentScore; set => currentScore = value; }
    
    private void Start()
    {
        SetUpMatch();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.PauseGame();
        }
    }

    public void SetUpMatch()
    {
        borderline.SetPositions(gameModeData.Bounds.BoundingBox);
        bumper =  Instantiate(gameModeData.BumperPrefab, Vector3.up, Quaternion.identity);
        bumper.Bounds = gameModeData.Bounds;
        ball = Instantiate(gameModeData.BallPrefab, bumper.transform.position += Vector3.up, Quaternion.identity);
        ball.Bounds = gameModeData.Bounds;
        ball.BallOutOfBounds = ResetMatch;
        currentScore = 0;
    }
    
    public void ResetMatch()
    {
        Debug.Log("Reset Match");
        StartCoroutine(DelayedReset());
    }
    
    IEnumerator DelayedReset()
    {
        bumper.transform.position = Vector3.up;
        ball.transform.position = bumper.transform.position += Vector3.up;
        yield return new WaitForSeconds(1);
        ball.Move(Vector2.up + Vector2.right);
    }

    public void AddScoreValue(int value)
    {
        currentScore += value;
    }
    
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
