using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnim : MonoBehaviour
{
    public GameObject canvas;
    private void Start()
    {
        Invoke("Active", 12f);
    }
    public void Active()
    {
        canvas.SetActive(true);
    }
}
