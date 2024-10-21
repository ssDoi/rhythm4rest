using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
                if (instance == null)
                {
                    GameObject container = new GameObject("UIManager");

                    instance = container.AddComponent<UIManager>();
                }
            }

            return instance;
        }
    }


    public TextMeshProUGUI score;
    public TextMeshProUGUI scorePercent;

    public void ChangeText(int score, int len)
    {
        this.score.text = score.ToString();
        this.scorePercent.text = ((float)score / len).ToString("F2") + "%";
    }
}
