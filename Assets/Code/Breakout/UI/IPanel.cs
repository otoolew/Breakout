using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IPanel
{
    void Open();
    void Close();
    UnityAction OnClose { get; set; }
}

