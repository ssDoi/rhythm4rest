using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{

    private static TimingManager instance;

    public static TimingManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TimingManager>();
                if (instance == null)
                {
                    GameObject container = new GameObject("TimingManager");

                    instance = container.AddComponent<TimingManager>();
                }
            }

            return instance;
        }
    }

    public Queue<GameObject> line1Note = new Queue<GameObject>();
    public Queue<GameObject> line2Note = new Queue<GameObject>();
    public Queue<GameObject> line3Note = new Queue<GameObject>();
    public Queue<GameObject> line4Note = new Queue<GameObject>();
    public Queue<GameObject> pedalNote = new Queue<GameObject>();


    [SerializeField] Transform center;
    [SerializeField] Transform[] timingRect;
    public int[] judgeScore;

    public int score;
    public int clearNoteCount;
    Vector3[] timingBoxs;

    Line line;

    private void Start()
    {
        line = GetComponent<Line>();
        timingBoxs = new Vector3[timingRect.Length];
    }

    public void DeQueue(int line)
    {
        switch (line)
        {
            case 1:
                line1Note.Dequeue();
                break;
            case 2:
                line2Note.Dequeue();
                break;
            case 3:
                line3Note.Dequeue();
                break;
            case 4:
                line4Note.Dequeue();
                break;
            case 5:
                pedalNote.Dequeue();
                break;
        }
        clearNoteCount++;

        UIManager.Instance.ChangeText(score, clearNoteCount);
    }

    public void Line1Down()
    {
        for (int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(center.position.x - timingRect[i].localScale.x / 13.3333f, center.position.x + timingRect[i].localScale.x / 13.3333f, 0);
        }
        GameObject note = line1Note.Peek();
        float t_notePosX = note.transform.position.x;
        float t_notePosY = note.transform.position.y;
        Debug.Log(t_notePosX);


        for (int j = 0; j < timingBoxs.Length; j++)
        {
            if (timingBoxs[j].x <= t_notePosX && t_notePosX <= timingBoxs[j].y && (transform.position.y - 2.25f) <= t_notePosY && (transform.position.y + 2.25f) >= t_notePosY)
            {
                note.SetActive(false);
                line1Note.Dequeue();



                switch (j)
                {
                    case 0:
                        Debug.Log("Perfect");
                        score += judgeScore[j];
                        break;
                    case 1:
                        Debug.Log("Cool");
                        score += judgeScore[j];
                        break;
                    case 2:
                        Debug.Log("Good");
                        score += judgeScore[j];
                        break;
                    case 3:
                        Debug.Log("Miss");
                        score += judgeScore[j];
                        break;
                }
                clearNoteCount++;
                UIManager.Instance.ChangeText(score, clearNoteCount);
                return;
            }
        }
    }

    public void Line2Down()
    {
        for (int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(center.position.x - timingRect[i].localScale.x / 13.3333f, center.position.x + timingRect[i].localScale.x / 13.3333f, 0);
        }
        GameObject note = line2Note.Peek();
        float t_notePosX = note.transform.position.x;
        float t_notePosY = note.transform.position.y;
        Debug.Log(t_notePosX);


        for (int j = 0; j < timingBoxs.Length; j++)
        {
            if (timingBoxs[j].x <= t_notePosX && t_notePosX <= timingBoxs[j].y && (transform.position.y - 2.25f) <= t_notePosY && (transform.position.y + 2.25f) >= t_notePosY)
            {
                note.SetActive(false);
                line2Note.Dequeue();



                switch (j)
                {
                    case 0:
                        Debug.Log("Perfect");
                        score += judgeScore[j];
                        break;
                    case 1:
                        Debug.Log("Cool");
                        score += judgeScore[j];
                        break;
                    case 2:
                        Debug.Log("Good");
                        score += judgeScore[j];
                        break;
                    case 3:
                        Debug.Log("Miss");
                        score += judgeScore[j];
                        break;
                }
                clearNoteCount++;
                UIManager.Instance.ChangeText(score, clearNoteCount);
                return;
            }
        }
    }

    public void Line3Down()
    {
        for (int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(center.position.x - timingRect[i].localScale.x / 13.3333f, center.position.x + timingRect[i].localScale.x / 13.3333f, 0);
        }
        GameObject note = line3Note.Peek();
        float t_notePosX = note.transform.position.x;
        float t_notePosY = note.transform.position.y;
        Debug.Log(t_notePosX);


        for (int j = 0; j < timingBoxs.Length; j++)
        {
            if (timingBoxs[j].x <= t_notePosX && t_notePosX <= timingBoxs[j].y && (transform.position.y - 2.25f) <= t_notePosY && (transform.position.y + 2.25f) >= t_notePosY)
            {
                note.SetActive(false);
                line3Note.Dequeue();



                switch (j)
                {
                    case 0:
                        Debug.Log("Perfect");
                        score += judgeScore[j];
                        break;
                    case 1:
                        Debug.Log("Cool");
                        score += judgeScore[j];
                        break;
                    case 2:
                        Debug.Log("Good");
                        score += judgeScore[j];
                        break;
                    case 3:
                        Debug.Log("Miss");
                        score += judgeScore[j];
                        break;
                }
                clearNoteCount++;
                UIManager.Instance.ChangeText(score, clearNoteCount);
                return;
            }
        }
    }

    public void Line4Down()
    {
        for (int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(center.position.x - timingRect[i].localScale.x / 13.3333f, center.position.x + timingRect[i].localScale.x / 13.3333f, 0);
        }
        GameObject note = line4Note.Peek();
        float t_notePosX = note.transform.position.x;
        float t_notePosY = note.transform.position.y;
        Debug.Log(t_notePosX);


        for (int j = 0; j < timingBoxs.Length; j++)
        {
            if (timingBoxs[j].x <= t_notePosX && t_notePosX <= timingBoxs[j].y && (transform.position.y - 2.25f) <= t_notePosY && (transform.position.y + 2.25f) >= t_notePosY)
            {
                note.SetActive(false);
                line4Note.Dequeue();



                switch (j)
                {
                    case 0:
                        Debug.Log("Perfect");
                        score += judgeScore[j];
                        break;
                    case 1:
                        Debug.Log("Cool");
                        score += judgeScore[j];
                        break;
                    case 2:
                        Debug.Log("Good");
                        score += judgeScore[j];
                        break;
                    case 3:
                        Debug.Log("Miss");
                        score += judgeScore[j];
                        break;
                }
                clearNoteCount++;
                UIManager.Instance.ChangeText(score, clearNoteCount);
                return;
            }
        }
    }

    public void PedalDown()
    {

    }


    public void Judge() 
    {


    }



}

