using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newSceneAsset", menuName = "Scene Managment/SceneAsset")]
public class SceneInfo : ScriptableObject
{
    [SerializeField] private string sceneName;
    public string SceneName { get => sceneName; private set => sceneName = value; }

    [SerializeField, TextArea] private string sceneDescription;
    public string SceneDescription { get => sceneDescription; set => sceneDescription = value; }
    
#if UNITY_EDITOR
    public UnityEditor.SceneAsset Scene;
    private void OnValidate()
    {
        //Set the scene name
        SceneName = Scene != null ? Scene.name : "";
    }
#endif
}
