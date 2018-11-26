using UnityEngine.Audio;

using UnityEngine;
[System.Serializable]
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private AudioSource as_audioSource;
    public AudioClip[] ac_coinSounds = new AudioClip[3];
    private AudioClip ac_lvlUp;
    public float f_volume;
    private int i_sCounter;

    // Use this for initialization
    void Start()
    {
        i_sCounter = 0;
        LoadSounds();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayCoinSound();
        }
    }

    void LoadSounds()
    {
        if (!GameObject.FindGameObjectWithTag("GAS")) return;

        as_audioSource = GameObject.FindGameObjectWithTag("GAS").GetComponent<AudioSource>();
        f_volume = 1;
        for (int i = 0; i < 3; i++)
        {
            ac_coinSounds[i] = Resources.Load<AudioClip>("Crane_Audio/Coin" + (i + 1).ToString());
        }
        ac_lvlUp = Resources.Load<AudioClip>("Crane_Audio/LvlUp");

    }

    public void PlayCoinSound()
    {
        if (i_sCounter == 3)
        {
            i_sCounter = 0;
        }
        as_audioSource.PlayOneShot(ac_coinSounds[i_sCounter], f_volume);
        i_sCounter++;
    }

    public void LvlUpSound()
    {
        as_audioSource.PlayOneShot(ac_lvlUp);
    }
}
