using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    #region Scene Managment -------------------------------------------------------------------------------------------
    public void LoadScene(GameModeData gameModeData)
    {
        SceneManager.LoadSceneAsync(gameModeData.SceneInfo.SceneName).completed += OnSceneLoadComplete;
    }
    public void LoadScene(SceneInfo sceneInfo)
    {
        SceneManager.LoadSceneAsync(sceneInfo.SceneName).completed += OnSceneLoadComplete;;
    }
    private void OnSceneLoadComplete(AsyncOperation obj)
    {
        Debug.Log("Completed Scene Load");
    }
    #endregion
}
