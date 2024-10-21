using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject STMaker;
    StageMaking SM;
    float Cspeed;
    float OneTime;
    public GameObject SheetB;
    GameObject JLine;
    Line JL;
    // Start is called before the first frame update
    void Start()
    {
        JLine = GameObject.Find("Judgement Line");
        JL = JLine.GetComponent<Line>();
        OneTime = SheetB.transform.GetChild(1).transform.localScale.x / JL.speed;
        Cspeed = 5 / OneTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * Cspeed);
    }
}
