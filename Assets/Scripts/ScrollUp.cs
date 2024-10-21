using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUp : MonoBehaviour
{
    GameObject STMaker;
    StageMaking SM;
    float Cspeed;
    float OneTime;
    GameObject JLine;
    Line JL;
    bool stat = false;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        JLine = GameObject.Find("Judgement Line");
        JL = JLine.GetComponent<Line>();
        OneTime = transform.GetChild(1).transform.localScale.x / JL.speed;
        Cspeed = 5 / OneTime;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (stat == false)
        {
            time += Time.deltaTime;
            if (time >= 3.0f)
                stat = true;
        }
        else
        {
            transform.Translate(Vector3.up * Time.deltaTime * Cspeed);
        }
    }
}
