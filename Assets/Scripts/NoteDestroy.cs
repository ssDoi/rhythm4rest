using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NoteDestroy : MonoBehaviour
{
    public int line;
    public ParticleSystem particle;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Delete());
    }
    
    IEnumerator Delete()
    {
        yield return new WaitForSeconds(0.3f);
        TimingManager.Instance.DeQueue(line);
        gameObject.SetActive(false);
       
    }

    private void OnDisable()
    {
        StopCoroutine(Delete());
        particle.Play();
    }
}
