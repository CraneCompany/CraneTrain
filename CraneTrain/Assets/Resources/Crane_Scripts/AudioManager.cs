using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //ALL AUDIO SOURCES:
    private AudioSource as_audioSource;

    [HideInInspector] public AudioClip[] ac_coinSounds = new AudioClip[3];
    [HideInInspector] public AudioClip ac_lvlUp;
    [HideInInspector] public float f_trainingVolume;
    [HideInInspector] public float f_globalVolume;
    private int i_sCounter;
    private GlobalParameterScript cs_globalParameterScript;
    private GameObject go_foveRig;

    void Start()
    {
        cs_globalParameterScript = GetComponent<GlobalParameterScript>();
        SceneChanger cs_sceneChanger = GetComponent<SceneChanger>();
        go_foveRig = cs_sceneChanger.go_foveRig;
        i_sCounter = 0;
        LoadSounds();
    }

    public void AudioOptionsUpdated()
    {
        //TODO: update all audiosources   
        as_audioSource.volume = f_globalVolume;
        
    }

    public void LoadSounds()
    {
        f_trainingVolume = cs_globalParameterScript.f_trainVolume;
        f_globalVolume = cs_globalParameterScript.f_globalVolume;

        as_audioSource = go_foveRig.GetComponentInChildren<AudioSource>();


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
        as_audioSource.PlayOneShot(ac_lvlUp, f_trainingVolume);
    }
}
