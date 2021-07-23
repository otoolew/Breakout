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
    
    [SerializeField] private CanvasGroup sceneFadeComp;
    public CanvasGroup SceneFadeComp { get => sceneFadeComp; set => sceneFadeComp = value; }
    [SerializeField] private float sceneFadeDuration;
    [SerializeField] private bool inSceneTransition;

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
    
    #region Scene Management ------------------------------------------------------------------------------------------
    public void LoadScene(string sceneName)
    {
        if (!inSceneTransition)
        {
            StartCoroutine(FadeAndSwitchScenes(sceneName));
        }
    }

    private IEnumerator FadeAndSwitchScenes(string sceneName)
    {
        yield return StartCoroutine(Fade(1));
        yield return SceneManager.LoadSceneAsync(sceneName);
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(Fade(0));
    }
    
    private IEnumerator Fade(float finalAlpha)
    {
        inSceneTransition = true;
        sceneFadeComp.blocksRaycasts = true; // Blocks player Clicking on other Scene or UI GameObjects
        float fadeSpeed = Mathf.Abs(sceneFadeComp.alpha - finalAlpha) / sceneFadeDuration;
        while (!Mathf.Approximately(sceneFadeComp.alpha, finalAlpha))
        {
            sceneFadeComp.alpha = Mathf.MoveTowards(sceneFadeComp.alpha, finalAlpha,
                fadeSpeed * Time.deltaTime);
            yield return null; // Wait 1 frame
        }
        inSceneTransition = false;
        sceneFadeComp.blocksRaycasts = false;
    }
    #endregion
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //Gizmos.DrawLine();
    }
}
