using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource as_audioSource;
    public AudioClip[] ac_coinSounds = new AudioClip[3];
    private AudioClip ac_lvlUp;
    public float f_trainingVolume;
    public float f_globalVolume;
    private int i_sCounter;
    private GlobalParameterScript cs_globalParameterScript;

    void Start()
    {
        cs_globalParameterScript = GetComponent<GlobalParameterScript>();
        i_sCounter = 0;
        LoadSounds();
    }

    public void AudioOptionsUpdated()
    {
        as_audioSource.volume = f_globalVolume;
    }

    void LoadSounds()
    {
        if (!GameObject.FindGameObjectWithTag("GAS")) return;
        f_trainingVolume = cs_globalParameterScript.f_trainVolume;
        f_globalVolume = cs_globalParameterScript.f_globalVolume;

        as_audioSource = GameObject.FindGameObjectWithTag("GAS").GetComponent<AudioSource>();
        for (int i = 0; i < 3; i++)
        {
            ac_coinSounds[i] = Resources.Load<AudioClip>("Crane_Audio/Coin" + (i + 1).ToString());
        }
        ac_lvlUp = Resources.Load<AudioClip>("Crane_Audio/LvlUp");

        AudioOptionsUpdated();
    }

    public void PlayCoinSound()
    {
        if (i_sCounter == 3)
        {
            i_sCounter = 0;
        }
        as_audioSource.PlayOneShot(ac_coinSounds[i_sCounter], f_trainingVolume);
        i_sCounter++;
    }

    public void LvlUpSound()
    {
        as_audioSource.PlayOneShot(ac_lvlUp);
    }
}
