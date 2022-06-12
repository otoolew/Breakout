using UnityEngine;

/// <summary>
/// A Breakable Brick with point value.
/// </summary>
public class Brick : MonoBehaviour
{
    #region Fields and Properties -------------------------------------------------------------------------------------
    /// <summary>
    /// Number of points the player receives when the ball hits the brick
    /// </summary>
    [SerializeField] private int pointValue;
    public int PointValue { get => pointValue; set => pointValue = value; }
    #endregion
    
    #region Monobehaviour ---------------------------------------------------------------------------------------------

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball")) // If the other gameobject has tag "Ball" it must be the ball 
        {
            SendMessageUpwards("AddScoreValue", pointValue, SendMessageOptions.RequireReceiver);
            Destroy(gameObject); // Remove Brick gameobject
        }
    }
    #endregion

}
