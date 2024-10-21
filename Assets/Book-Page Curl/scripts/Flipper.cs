using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Flipper : MonoBehaviour
{
    AutoFlip AF;
    Book book;
    // Start is called before the first frame update
    void Start()
    {
        AF = GetComponent<AutoFlip>();
        book = GetComponent<Book>();

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AF.FlipLeftPage();
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            AF.FlipRightPage();
        }
        else if(Input.GetKeyDown(KeyCode.Return))
        {
            GameManager.Instance.songNumber = book.currentPage / 2 - 1;
            GameManager.Instance.goToPlay();
        }
    }
}
