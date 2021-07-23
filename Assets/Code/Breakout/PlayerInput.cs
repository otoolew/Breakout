using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Bumper bumper;
    public Bumper Bumper { get => bumper; set => bumper = value; }
    
    [SerializeField] private Vector2 moveAxis;
    public Vector2 MoveAxis { get => moveAxis; set => moveAxis = value; }
    
    private void Update()
    {
        moveAxis = new Vector2();
        if (Input.GetKey(KeyCode.A))
        {
            moveAxis += new Vector2(-1, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveAxis += new Vector2(1, 0);
        }
        bumper.Move(moveAxis);
    }
}
