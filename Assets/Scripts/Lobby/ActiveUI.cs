using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveUI : MonoBehaviour
{
    CanvasGroup canvas;
    GameObject book;
    bool bookA = false;
    void OnEnable()
    {
        canvas = GetComponent<CanvasGroup>();
        book = canvas.transform.GetChild(3).gameObject;
        canvas.alpha = 0f;
        book.SetActive(false);
        StartCoroutine(ActiveCanvas());
    }

    IEnumerator ActiveCanvas()
    {

        while(canvas.alpha < 1f)
        {
           
            canvas.alpha += Time.deltaTime;
            yield return null;
        }
    }
    public void ActiveBook()
    {
        canvas.transform.GetChild(0).gameObject.SetActive(false);
        canvas.transform.GetChild(1).gameObject.SetActive(false);
        book.SetActive(true);
        bookA = true;

    }
    private void Update()
    {
        if (bookA == true)
        {
            if (book.GetComponent<RectTransform>().anchoredPosition.y < 0)
            {
                book.GetComponent<RectTransform>().Translate(Vector3.up * Time.deltaTime * 900);
            }
        }
    }
}
