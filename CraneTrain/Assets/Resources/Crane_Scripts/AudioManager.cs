using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource as_audioSource;
    public AudioClip[] ac_coinSounds = new AudioClip[3];
    public float f_volume;
    private int i_sCounter;

    // Use this for initialization
    void Start()
    {
        i_sCounter = 0;
        FillCoinSounds();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaySound();
        }
    }

    void FillCoinSounds()
    {
        as_audioSource = GameObject.FindGameObjectWithTag("GAS").GetComponent<AudioSource>();
        f_volume = 1;
        for (int i = 0; i < 3; i++)
        {
            ac_coinSounds[i] = Resources.Load<AudioClip>("Crane_Audio/Coin" + (i + 1).ToString());
        }
    }

    public void PlaySound()
    {
        if (i_sCounter == 3)
        {
            i_sCounter = 0;
        }
        as_audioSource.PlayOneShot(ac_coinSounds[i_sCounter], f_volume);
        i_sCounter++;
    }
}
