using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ScriptableObject that stores information about scenes into an asset.
/// </summary>
[CreateAssetMenu(fileName = "newSceneAsset", menuName = "Scene Managment/SceneAsset")]
public class SceneInfo : ScriptableObject
{
    [SerializeField] private string sceneName;
    /// <summary>
    /// The name of the scene
    /// </summary>
    public string SceneName { get => sceneName; private set => sceneName = value; }

    [SerializeField, TextArea] private string sceneDescription;
    /// <summary>
    /// Description of a scene
    /// </summary>
    public string SceneDescription { get => sceneDescription; set => sceneDescription = value; }
    
#if UNITY_EDITOR
    /// <summary>
    /// The scene assigned.
    /// </summary>
    public UnityEditor.SceneAsset Scene;
    private void OnValidate()
    {
        //Set the scene name once selected in editor
        SceneName = Scene != null ? Scene.name : "";
    }
#endif
}
