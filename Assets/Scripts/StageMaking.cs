using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class StageMaking : MonoBehaviour
{
    public GameObject Dnote;
    public GameObject Lnote;
    public GameObject Rnote;
    public float SongLength;
    public int BPM;
    public GameObject SheetB;
    float OneTime;
    int SheetN;
    GameObject JLine;
    Line JL;
    public GameObject[] SheetBs;
    public bool isEnd = false;
    GameObject canvas;
   // GameObject GM;
   // GameManager GManager;
    List<Note> line1 = new List<Note>();
    List<Note> line2 = new List<Note>();
    List<Note> line3 = new List<Note>();
    List<Note> line4 = new List<Note>();
    List<Note> pedal = new List<Note>();


    void Awake()
    {
       // GM = GameObject.Find("Game Manager");
       // GManager = GM.GetComponent<GameManager>();
        SongLength = GameManager.Instance.musics[GameManager.Instance.songNumber].songLength;
        BPM = GameManager.Instance.musics[GameManager.Instance.songNumber].bpm;
        ReadNoteFile();
    }

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        InstantiateBoard();
        InstantiateNotes(line1, (float)-0.2);
        InstantiateNotes(line2, (float)-0.4);
        InstantiateNotes(line3, (float)-0.6);
        InstantiateNotes(line4, (float)-0.8);
        /*for(int i = 0; i<line1.Count; i++)
        {
            Debug.Log(line1[i].type);
            Debug.Log(line1[i].line);
            Debug.Log(line1[i].time);

        }*/
    }
    void InstantiateBoard()
    {
        JLine = GameObject.Find("Judgement Line");
        JL = JLine.GetComponent<Line>();
        OneTime = SheetB.transform.GetChild(1).transform.localScale.x / JL.speed;

        SheetN = (int)Mathf.Ceil(SongLength / OneTime);
        SheetBs = new GameObject[SheetN];
        for (int i = 0; i < SheetN; i++)
        {
            SheetBs[i]=Instantiate(SheetB, new Vector3(0, (float)(- (i * (SheetB.transform.GetChild(1).transform.localScale.y + 0.5))), 0), SheetB.transform.rotation);
        }
        

    }
    void InstantiateNotes(List<Note> line, float yoffset)
    {
        float Rseconds = 0;
        for(int i = 0; i<line.Count; i++)
        {
            Rseconds = (float)60 / (BPM * 12) * line[i].time; ;
            int SN = (int)(Rseconds / OneTime);
            GameObject note = new GameObject();
            if (line[i].type == Note.Type.defaultNote)
            {
                note =Instantiate(Dnote , new Vector3(Rseconds / OneTime - SN - 0.5f, 0.5f + yoffset, 0), Dnote.transform.rotation);
                note.GetComponent<NoteDestroy>().line = line[i].line;
                note.transform.SetParent(SheetBs[SN].transform.GetChild(1).transform, false);
                note.transform.localScale = new Vector3(0.056f, 0.136f);
            }
            else if(line[i].type == Note.Type.longNote)
            {
                note = Instantiate(Lnote, new Vector3(Rseconds / OneTime - SN - 0.5f, 0.5f + yoffset, 0), Lnote.transform.rotation);
                note.GetComponent<NoteDestroy>().line = line[i].line;
                note.transform.SetParent(SheetBs[SN].transform.GetChild(1).transform, false);
                note.transform.localScale = new Vector3(0.056f, 0.136f);
            }
            else if (line[i].type == Note.Type.obstacle)
            {
                note = Instantiate(Rnote, new Vector3(Rseconds / OneTime - SN - 0.5f, 0.5f + yoffset, 0), Rnote.transform.rotation);
                note.GetComponent<NoteDestroy>().line = line[i].line;
                note.transform.SetParent(SheetBs[SN].transform.GetChild(1).transform, false);
                note.transform.localScale = new Vector3(0.056f, 0.136f);
            }


            switch (line[i].line)
            {
                case 1:
                    TimingManager.Instance.line1Note.Enqueue(note);
                    break;
                case 2:
                    TimingManager.Instance.line2Note.Enqueue(note);
                    break;
                case 3:
                    TimingManager.Instance.line3Note.Enqueue(note);
                    break;
                case 4:
                    TimingManager.Instance.line4Note.Enqueue(note);
                    break;
                case 5:
                    TimingManager.Instance.pedalNote.Enqueue(note);
                    break;

            }

        }

    }


    void Update()
    {
        if(SheetBs[SheetBs.Length -1].transform.position.y >= 11)
        {

            canvas.transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition = new Vector2(900, -400);
            canvas.transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition = new Vector2(900, -500);
            canvas.transform.GetChild(3).gameObject.SetActive(true);
            GameManager.Instance.StopMusic();
            if(Input.GetKeyDown(KeyCode.Return))
            {
                GameManager.Instance.ReturnLobby();

            }
        }
    }

    void ReadNoteFile()
    {
        line1.Clear();
        line2.Clear();
        line3.Clear();
        line4.Clear();
        pedal.Clear();

        TextAsset textFile = Resources.Load(GameManager.Instance.musics[GameManager.Instance.songNumber].songName) as TextAsset;
        StringReader stringReader = new StringReader(textFile.text);

        int lineIndex = 0;


        while (stringReader != null)
        {

            lineIndex++;
            string line = stringReader.ReadLine();


            if (line == null)
                break;


            string[] noteList;
            noteList = line.Split("\t");

            for (int i = 0; i < noteList.Length; i++)
            {
                Note noteData = new Note();

                int curNote = int.Parse(noteList[i]);

                if (curNote == 0)
                    continue;

                switch (curNote)
                {
                    case 1:
                        noteData.type = Note.Type.defaultNote;
                        break;
                    case 2:
                        noteData.type = Note.Type.longNote;
                        break;
                    case 3:
                        noteData.type = Note.Type.obstacle;
                        break;

                }

                noteData.line = lineIndex;
                noteData.time = i;

                switch (lineIndex)
                {
                    case 1:
                        line1.Add(noteData);
                        break;
                    case 2:
                        line2.Add(noteData);
                        break;
                    case 3:
                        line3.Add(noteData);
                        break;
                    case 4:
                        line4.Add(noteData);
                        break;
                    case 5:
                        pedal.Add(noteData);
                        break;


                }
            }

        }


        stringReader.Close();
    }
}
