using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    #region Fields and Properties -------------------------------------------------------------------------------------
    /// <summary>
    /// The static reference to the instance
    /// </summary>
    public static GameManager Instance { get; protected set; }
    /// <summary>
    /// Gets whether an instance of this singleton exists
    /// </summary>
    public static bool InstanceExists => Instance != null;

    [SerializeField] private MainCanvas mainCanvas;
    public MainCanvas MainCanvas { get => mainCanvas; set => mainCanvas = value; }
    
    [SerializeField] private GameState gameState;
    public GameState GameState { get => gameState; set => gameState = value; }
    #endregion
    
    #region Monobehaviour ---------------------------------------------------------------------------------------------
    /// <summary>
    /// Awake method to associate singleton with instance
    /// </summary>
    private void Awake()
    {
        if (InstanceExists)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    /// <summary>
    /// OnDestroy method to clear singleton association
    /// </summary>
    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
    #endregion
    
    #region Game State ---------------------------------------------------------------------------------------------

    public void PauseGame()
    {
        
    }
    #endregion
}
