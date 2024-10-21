using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Line1"))
        {
            TimingManager.Instance.Line1Down();          
        }
        if (Input.GetButtonDown("Line2"))
        {
            TimingManager.Instance.Line2Down();
        }
        if (Input.GetButtonDown("Line3"))
        {
            TimingManager.Instance.Line3Down();
        }
        if (Input.GetButtonDown("Line4"))
        {
            TimingManager.Instance.Line4Down();
        }
        if (Input.GetButtonDown("Pedal"))
        {
            TimingManager.Instance.PedalDown();
        }
    }
}
