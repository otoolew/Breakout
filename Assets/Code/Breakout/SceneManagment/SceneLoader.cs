using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Scene Loader uses GameModeData or SceneInfo assets to handle scene loading.
/// </summary>
public class SceneLoader : MonoBehaviour
{
    #region Scene Managment -------------------------------------------------------------------------------------------
    /// <summary>
    /// Loads a Scene via GameModeData
    /// </summary>
    /// <param name="gameModeData"></param>
    public void LoadScene(GameModeData gameModeData)
    {
        SceneManager.LoadSceneAsync(gameModeData.SceneInfo.SceneName).completed += OnSceneLoadComplete;
    }
    /// <summary>
    /// Loads a scene using the scene name from a SceneInfo asset.
    /// </summary>
    /// <param name="sceneInfo"></param>
    public void LoadScene(SceneInfo sceneInfo)
    {
        SceneManager.LoadSceneAsync(sceneInfo.SceneName).completed += OnSceneLoadComplete;;
    }
    /// <summary>
    /// Calls after the scene load is complete.
    /// </summary>
    /// <param name="obj">SceneManagers completed AsyncOperation</param>
    private void OnSceneLoadComplete(AsyncOperation obj)
    {
        Debug.Log("Completed Scene Load");
    }
    #endregion
}
