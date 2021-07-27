using TMPro;
using UnityEngine;

/// <summary>
/// Class that handles the Score UI
/// </summary>
public class ScorePanel : MonoBehaviour
{
    #region Fields and Properties -------------------------------------------------------------------------------------
    /// <summary>
    /// Text Component use for the High Score UI
    /// </summary>
    [SerializeField] private TMP_Text highScoreText;
    /// <summary>
    /// Text Component use for Current Score UI
    /// </summary>
    [SerializeField] private TMP_Text currentScoreText;
    /// <summary>
    /// Text Component use for Hit Points UI
    /// </summary>
    [SerializeField] private TMP_Text hitPointsText;
    #endregion

    #region Score Text Methods
    /// <summary>
    /// Sets the Current Score text string value
    /// </summary>
    /// <param name="value"></param>
    public void SetCurrentScore(int value)
    {
        currentScoreText.text = "Current Score " + value;
    }

    /// <summary>
    /// Sets the High Score text string value
    /// </summary>
    /// <param name="value"></param>
    public void SetHighScore(int value)
    {
        highScoreText.text = "Mode High Score " + value;
    }

    /// <summary>
    /// Sets the Hit Points text string value
    /// </summary>
    /// <param name="value"></param>
    public void SetHitPoints(int value)
    {
        hitPointsText.text = "Ball Count " + value;
    }
    #endregion
}
