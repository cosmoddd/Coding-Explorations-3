using UnityEngine;
using System.Collections;

public class LoopControl : MonoBehaviour
{


    public AudioClip[] clipList;
    public AudioSource audioSource;
    public int loopAmount;
    public int currentPlayCount;
    public float loopDuration;
    public float currentPosition;


    // Use this for initialization
    void Start()
    {

        currentPlayCount = 0;
        loopAmount = Random.Range(2, 4);
        //audioSource.clip = clipList[Random.Range(0, 8)];

        // PlayThroughClip();

        //  audioSource.PlayOneShot(audioSource.clip);

    }

    IEnumerator LoopAudio(int startingLoopAmt)
    {
        while (true)
        {
            currentPlayCount = 0;
            audioSource.clip = clipList[Random.Range(0, 8)];
            loopDuration = audioSource.clip.length;
            
            for (int i = 0; i < loopAmount; i++)
            {
                audioSource.Play();
                currentPlayCount++;
                yield return new WaitForSeconds(audioSource.clip.length);
            }
            loopAmount = Random.Range(2, 4);
            Debug.Log("End of Loop Sequence");
        }
    }

    void OnMouseDown()
    {
        StopCoroutine("LoopAudio");
      //  currentPlayCount = 0;
        //audioSource.clip = clipList[Random.Range(0, 8)];
        //loopDuration = audioSource.clip.length;
        StartCoroutine(LoopAudio(loopAmount));

        //PlayThroughClip();
    }

    void Update()
    {


       currentPosition = audioSource.time;
        

        //PlayThroughClip();

        //Debug.Log(audioSource.time);
        //if (!audioSource.isPlaying)
        //{
        //    PlayThroughClip();
        //}

    }

    //void PlayThroughClip()
    //{

    //      if (currentPosition >= (loopDuration-.02))
    //        {
    //            Debug.Log("you have reached the end of the playback file");
    //        }

    //for (currentPlayCount = 0; currentPlayCount < loopTimes; currentPlayCount++)
    //{

    //    //audioSource.PlayOneShot(audioSource.clip);

    //    Debug.Log("one time playing");

    //    if (currentPosition == loopDuration)
    //    {
    //        Debug.Log("you have reached the end of the playback file");
    //    }
    //}
}



