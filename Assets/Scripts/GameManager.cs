using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int SceneIndex;
    public int songNumber = 0;
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject container = new GameObject("GameManager");

                    instance = container.AddComponent<GameManager>();
                }
            }

            return instance;
        }
    }


    public bool doGamePlay;
    public float speed;
    GameObject T;
    public TextMeshProUGUI speedT;
    bool isLobby = false;

    
    AudioSource audioSource;
    public AudioClip[] songs;
    public List<Music> musics = new List<Music>();

    private void Awake()
    {
        SceneIndex = 1;
        audioSource = GetComponent<AudioSource>();
        speedT.text = speed.ToString();
        DontDestroyOnLoad(this);
        musics.Add(new Music()
        {
            songName = "dream",
            songLength = 130,
            bpm = 150,
            music = songs[0]
        });
        musics.Add(new Music()
        {
            songName = "test1",
            songLength = 90,
            bpm = 100,
            music = songs[1]
        });
        musics.Add(new Music()
        {
            songName = "Last Minute of Party",
            songLength = 56,
            bpm = 215,
            music = songs[2]
        });
    }

    public void PlayMusic()
    {
        doGamePlay = true;
        audioSource.PlayOneShot(musics[songNumber].music);
    }
    public void StopMusic()
    {
        audioSource.Stop();
    }
    public void ReturnLobby()
    {
        SceneIndex = 2;
        SceneManager.LoadScene("Lobby");
        isLobby = true;

    }
    public void goToPlay()
    {
        SceneIndex = 3;
        SceneManager.LoadScene("SampleScene");
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && SceneIndex != 3)
        {
            speed++;
            speedT.text = speed.ToString();
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) && SceneIndex != 3)
        {
            speed--;
            speedT.text = speed.ToString();
        }
        if(Input.GetKeyDown(KeyCode.Escape) && SceneIndex ==3)
        {
            StopMusic();
            ReturnLobby();
        }
        if(SceneIndex == 2 && isLobby)
        {
            speedT = GameObject.Find("Canvas").transform.GetChild(3).transform.GetChild(8).transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            speedT.text = speed.ToString();
            isLobby = false;
        }
    }
}
