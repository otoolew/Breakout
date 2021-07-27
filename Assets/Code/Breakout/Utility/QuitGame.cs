using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Quits the Application
/// </summary>
public class QuitGame : MonoBehaviour
{
    /// <summary>
    /// Quits the game.
    /// </summary>
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Used to Quit in Editor
#else
        Application.Quit();
#endif
    }
}
