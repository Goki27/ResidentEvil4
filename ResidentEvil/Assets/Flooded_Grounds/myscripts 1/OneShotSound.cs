using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotSound : MonoBehaviour
{
    private AudioSource myAudio;
    private Collider col;
    [SerializeField] bool onetime = false;
    [SerializeField] float pauseTime = 5.0f;





    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        col = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            myAudio.Play();
            col.enabled = false;
            if (onetime == false)
            {
                StartCoroutine(Resat());
            }
            else
                Destroy(gameObject, pauseTime);
        }
    }


    IEnumerator Resat()
    {

        yield return new WaitForSeconds(pauseTime);     
    }
}