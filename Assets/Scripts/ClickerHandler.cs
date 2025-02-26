using System;
using UnityEngine;

public class ClickerHandler : MonoBehaviour
{
    public KeyCode clickerUpAssignedKey = KeyCode.PageUp;
    public KeyCode clickerDownAssignedKey = KeyCode.PageDown;
    public Action<int> OnClickerPressed;


    void Update()
    {
        if (Input.GetKeyDown(clickerUpAssignedKey))
        {
            OnClickerPressed?.Invoke(1);
            Debug.LogAssertion($"Clicker Pressed:{clickerUpAssignedKey.ToString()}");

        }
        if (Input.GetKeyDown(clickerDownAssignedKey))
        {
            OnClickerPressed?.Invoke(0);
            Debug.LogAssertion($"Clicker Pressed:{clickerDownAssignedKey.ToString()}");

        }
    }
}
