using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StartTime : MonoBehaviour
{
    float time=3.0f;
    public TextMeshProUGUI startT;
    int stime;
    // Start is called before the first frame update
    void Start()
    {
        startT.text = "3";
        StartCoroutine("CountDown");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CountDown()
    {
        
        yield return new WaitForSeconds(1f);
        startT.text = "2";
        yield return new WaitForSeconds(1f);
        startT.text = "1";
        yield return new WaitForSeconds(1f);
        GameManager.Instance.PlayMusic();
        startT.gameObject.SetActive(false);

    }

}
