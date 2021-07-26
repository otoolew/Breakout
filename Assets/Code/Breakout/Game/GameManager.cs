using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    
    [SerializeField] private GameMode gameMode;
    public GameMode GameMode { get => gameMode; set => gameMode = value; }
    

    
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
    
    #region Game State ------------------------------------------------------------------------------------------------
    /// <summary>
    /// Pauses the game.
    /// </summary>
    public void PauseGame()
    {
        if (gameState == GameState.PAUSED)
        {
            mainCanvas.SetPauseMenuActive(true);
            gameState = GameState.RUNNING;
            Time.timeScale = 1.0f;
        }
        else
        {
            mainCanvas.SetPauseMenuActive(false);
            gameState = GameState.PAUSED;
            Time.timeScale = 0.0f;
        }
    }
    /// <summary>
    /// Resumes the game.
    /// </summary>
    public void ResumeGame()
    {
        gameState = GameState.RUNNING;
        Time.timeScale = 1.0f;
    }
    /// <summary>
    /// Quits the game.
    /// </summary>
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Used to Quit in Editor
#else
        Application.Quit();
#endif
    }
    #endregion
    
    #region Scene Managment -------------------------------------------------------------------------------------------
    public void LoadScene(GameModeData gameModeData)
    {
        SceneManager.LoadSceneAsync(gameModeData.SceneInfo.SceneName).completed += OnSceneLoadComplete;
    }
    private void OnSceneLoadComplete(AsyncOperation obj)
    {
        Debug.Log("Completed Scene Load");
        gameMode = FindObjectOfType<GameMode>();
    }
    
    #endregion
}
