using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RLine : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject JLine;
    Line JL;
    Vector3 FirstPos;
    float OneTime;
    public GameObject SheetB;
    float Cspeed;
    GameObject ST;
    StageMaking stMaker;
    int i = 1;

    void Start()
    {
        JLine = GameObject.Find("Judgement Line");
        JL = JLine.GetComponent<Line>();
        OneTime = SheetB.transform.GetChild(1).transform.localScale.x / JL.speed;
        Cspeed = 5 / OneTime;
        ST = GameObject.Find("StageMaker");
        stMaker = ST.GetComponent<StageMaking>();
        transform.SetParent(stMaker.SheetBs[1].transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (JLine.transform.position.x >= 6 && JLine.transform.position.x <= 8)
        {
            transform.Translate(Vector3.right * JL.speed * Time.deltaTime);
        }
        else if (JLine.transform.position.x == -8)
        {
            if (i == stMaker.SheetBs.Length-1)
            {
                Destroy(gameObject);
            }
            else
            {
                transform.SetParent(stMaker.SheetBs[++i].transform, false);
                transform.localPosition = new Vector3(-10, 2.5f);
            }
        }

        

    }
}
