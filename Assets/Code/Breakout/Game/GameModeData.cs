using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Breakout/Game Mode Data", fileName = "newGameMode")]
public class GameModeData : ScriptableObject
{
    [SerializeField] private SceneInfo sceneInfo;
    public SceneInfo SceneInfo { get => sceneInfo; set => sceneInfo = value; }
    
    [SerializeField, TextArea] private string gameModeDescription;
    public string GameModeDescription { get => gameModeDescription; set => gameModeDescription = value; }

    [SerializeField] private Bumper bumperPrefab;
    public Bumper BumperPrefab { get => bumperPrefab; set => bumperPrefab = value; }
    
    [SerializeField] private Ball ballPrefab;
    public Ball BallPrefab { get => ballPrefab; set => ballPrefab = value; }

    [SerializeField] private Bounds bounds;
    public Bounds Bounds { get => bounds; set => bounds = value; }
    
    [SerializeField] private int ballLimit;
    public int BallLimit { get => ballLimit; set => ballLimit = value; }
    
    [SerializeField] private int brickCount;
    public int BrickCount { get => brickCount; set => brickCount = value; }
}
