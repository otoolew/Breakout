using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Breakout/GameMode", fileName = "newGameMode")]
public class GameMode : ScriptableObject
{
    [SerializeField] private Ball ballPrefab;
    public Ball BallPrefab { get => ballPrefab; set => ballPrefab = value; }
    
    [SerializeField] private Ball ball;
    public Ball Ball { get => ball; set => ball = value; }
    
    [SerializeField] private Bounds bounds;
    public Bounds Bounds { get => bounds; set => bounds = value; }

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(StartGameRoutine());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartGame()
    { 

    }

    IEnumerator StartGameRoutine()
    {
        yield return new WaitForSeconds(1.0f);
        ball = Instantiate(ballPrefab, new Vector3(0, -7.25f, 0), Quaternion.identity);
        
    }
}
