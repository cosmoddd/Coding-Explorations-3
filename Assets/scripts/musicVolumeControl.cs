using UnityEngine;
using System.Collections;

public class musicVolumeControl : MonoBehaviour {

    public AudioSource audioSource;
    public LoopControl loopControl;
    public float currentVolume;
    public float target;
    public int testLoopCount;
    public float testLoopDuration;


    // Use this for initialization
    void Start () {

        //thing.audioSource;
	
	}
	
	// Update is called once per frame
	void Update () {

        testLoopDuration = loopControl.loopDuration;

        updateVolume();

        testLoopCount = loopControl.currentPlayCount;
        if (testLoopCount == 1){
            target = 1;
        }
        if (testLoopCount == loopControl.loopAmount)
            {
            target = 0;
        }
	}

    void updateVolume()
    {
        audioSource.volume = currentVolume;
        currentVolume = Mathf.SmoothStep(currentVolume, target, (Time.deltaTime*loopControl.loopDuration));
    }

}
