using UnityEngine;
using System.Collections;

public class LoopControl : MonoBehaviour
{


    public AudioClip[] clipList;
    public AudioSource[] audioSource;
    public int[] loopAmount;
    public int[] currentPlayCount;
    public float[] loopDuration;
    public float[] currentPosition;


    // Use this for initialization
    void Start()
    {
     

        currentPlayCount[0] = 0;
        loopAmount[0] = Random.Range(2, 4);
        //audioSource.clip = clipList[Random.Range(0, 8)];

        // PlayThroughClip();

        //  audioSource.PlayOneShot(audioSource.clip);

    }

    IEnumerator LoopAudio1(int startingLoopAmt)
    {
        while (true)
        {
            currentPlayCount[0] = 0;
            audioSource[0].clip = clipList[Random.Range(0, 8)];
            loopDuration[0] = audioSource[0].clip.length;

			
			for (int i = 0; i < loopAmount[0]; i++)
            {
                audioSource[0].Play();
                currentPlayCount[0]++;
                yield return new WaitForSeconds(audioSource[0].clip.length);
            }
            loopAmount[0] = Random.Range(2, 4);
            Debug.Log("End of Loop 1 Sequence");
        }
    }

	IEnumerator LoopAudio2(int startingLoopAmt)
	{
		while (true)
		{
			currentPlayCount[1] = 0;
			audioSource[1].clip = clipList[Random.Range(0,8)];
			loopDuration[1] = audioSource[1].clip.length;
			
			
			for (int i = 0; i < loopAmount[1]; i++)
			{
				audioSource[1].Play();
				currentPlayCount[1]++;
				yield return new WaitForSeconds(audioSource[0].clip.length);
			}
			loopAmount[1] = Random.Range(2, 4);
			Debug.Log("End of Loop 2 Sequence");
		}
	}

    void OnMouseDown()
    {
        StopCoroutine("LoopAudio");

        StartCoroutine(LoopAudio1(loopAmount[0]));
    }

    void Update()
    {

       currentPosition[0] = audioSource[0].time;
		currentPosition [1] = audioSource [1].time;

    }

}



