using UnityEngine;
using System.Collections;

public class musicVolumeControl : MonoBehaviour {

    public AudioSource[] audioSource;
    public LoopControl loopControl;
    public float currentVolume;
    public float target;
    public int[] testLoopCount;
    public float[] testLoopDuration;


    // Use this for initialization
    void Start () {

        //thing.audioSource;
	
	}
	
	// Update is called once per frame
	void Update () {

	   //     testLoopDuration[0] = loopControl.loopDuration[0];

        updateVolume();

        testLoopCount[0] = loopControl.currentPlayCount[0];
        if (testLoopCount[0] == 1){
            target = 1;
        }
        if (testLoopCount[0] == loopControl.loopAmount[0])
            {
            target = 0;
        }
	}

    void updateVolume()
    {
        audioSource[0].volume = currentVolume;
        currentVolume = Mathf.SmoothStep(currentVolume, target, (Time.deltaTime*loopControl.loopDuration[0]));
    }

}
