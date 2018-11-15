using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    private AudioSource as_audioSource;
    public AudioClip[] ac_coinSounds = new AudioClip[4];
    public float f_volume;

	// Use this for initialization
	void Start () {
        as_audioSource = GameObject.FindGameObjectWithTag("GAS").GetComponent<AudioSource>();
        ac_coinSounds[0] = Resources.Load<AudioClip>("Crane_Audio/Coin1");
        f_volume = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(ac_coinSounds[0]);
            as_audioSource.clip = ac_coinSounds[0];
            as_audioSource.PlayOneShot(ac_coinSounds[0], f_volume);

        }
    }
}
