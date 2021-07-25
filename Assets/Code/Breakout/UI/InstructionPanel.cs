using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InstructionPanel : MonoBehaviour
{
    public UnityAction onClosePanel { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        onClosePanel = () => { Debug.Log("Nothing Assigned");};
    }

    public void ClosePanel()
    {
        onClosePanel?.Invoke();
    }
}
