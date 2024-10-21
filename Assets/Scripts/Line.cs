using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public float speed;
    private const float xRange = 8;
    float OneTime;
    public GameObject SheetB;
    float Cspeed;
    bool stat = false;
    float time = 0;
    int i = 0;
    GameObject ST;
    StageMaking stMaker;
  //  GameObject GM;
   // GameManager GManager;
    private void Awake()
    {
     //   GM = GameObject.Find("Game Manager");
      //  GManager = GM.GetComponent<GameManager>();
        speed = GameManager.Instance.speed;
    }
    private void Start()
    {
        OneTime = SheetB.transform.GetChild(1).transform.localScale.x / speed;
        Cspeed = 5 / OneTime;
        ST = GameObject.Find("StageMaker");
        stMaker = ST.GetComponent<StageMaking>();
        transform.SetParent(stMaker.SheetBs[0].transform, false); 
    }

    void LateUpdate()
    {
        if (stat == false)
        {
            time += Time.deltaTime;
            if (time >= 3.0f)
                stat = true;
        }
        else
        {
            Move();
        }
    }


    void Move()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        
        if (transform.position.x >= xRange && i + 1 < stMaker.SheetBs.Length)
        {
            transform.SetParent(stMaker.SheetBs[++i].transform, false);
            transform.localPosition = new Vector3(-8, 2.5f);
        }
        else if (i == stMaker.SheetBs.Length)
        {
            Destroy(gameObject);
        }


    }
}
