using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioSourceBGM;
    public AudioSource audioSourceSFX;

    public Slider sliderBGM;
    public Slider sliderSFX;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void Start()
    {
        LoadVolume();
        sliderBGM.value = audioSourceBGM.volume;
        sliderSFX.value = audioSourceSFX.volume;
    }

    void LoadVolume()
    {
        audioSourceBGM.volume = DataGame.instance.dataClass.volumeBGM;
        audioSourceSFX.volume = DataGame.instance.dataClass.volumeSFX;
    }

    public void SetVolumeBGM(float value)
    {
        DataGame.instance.dataClass.volumeBGM = value;
        LoadVolume();
    }
    public void SetVolumeSFX(float value)
    {
        DataGame.instance.dataClass.volumeSFX = value;
        LoadVolume();
    }



    [Header("BGM")]
    public AudioClip mainmenuBgm;
    public AudioClip gameplayBgm;

    [Header("SFX")]
    public AudioClip SFXClickButton;
    public AudioClip SFXCicak;
    public AudioClip SFXPlayerWalk;
    public AudioClip SFXFail;
    public AudioClip SFXComplete;
    public AudioClip SFXSignal;

    public void SetBGM(string value)
    {
        if (audioSourceBGM.clip.name == value) return;

        if (value == mainmenuBgm.name)
        {
            audioSourceBGM.clip = mainmenuBgm;
            audioSourceBGM.Play();
        }
        else if (value == gameplayBgm.name)
        {
            audioSourceBGM.clip = gameplayBgm;
            audioSourceBGM.Play();
        }
        else
        {
            Debug.Log("Missing Audio : " + value);
        }
    }

    public void SetSFX(string value)
    {
        if (value == SFXComplete.name)
        {
            audioSourceSFX.PlayOneShot(SFXComplete);
        }
        else if (value == SFXFail.name)
        {
            audioSourceSFX.PlayOneShot(SFXFail);
        }
        else if (value == SFXClickButton.name)
        {
            audioSourceSFX.PlayOneShot(SFXClickButton);
        }
        else if (value == SFXSignal.name)
        {
            audioSourceSFX.PlayOneShot(SFXSignal);
        }
        else
        {
            Debug.Log("Missing Audio : " + value);
        }
    }

    AudioSource audioSourcePlayerWalk;
    AudioSource audioSourceklaksonSfx;
    AudioSource audioSourcePolisiSfx;
    public void SetLoopSfx(string value, bool condition)
    {
        if (value == SFXComplete.name)
        {
            if (audioSourcePlayerWalk == null) audioSourcePlayerWalk = Instantiate(audioSourceBGM, transform);
            audioSourcePlayerWalk.name = "AudioSource " + value;
            if (condition)
            {
                audioSourcePlayerWalk.clip = SFXComplete;
                audioSourcePlayerWalk.Play();
                audioSourcePlayerWalk.volume = 0.4f;
            }
            else
            {
                audioSourcePlayerWalk.Stop();
            }
        }
        else if (value == SFXPlayerWalk.name)
        {
            if (audioSourceklaksonSfx == null) audioSourceklaksonSfx = Instantiate(audioSourceBGM, transform);
            audioSourceklaksonSfx.name = "AudioSource " + value;
            if (condition)
            {
                audioSourceklaksonSfx.clip = SFXPlayerWalk;
                audioSourceklaksonSfx.Play();
            }
            else
            {
                audioSourceklaksonSfx.Stop();
            }
        }
        else
        {
            Debug.Log("Missing Audio : " + value);
        }

    }
}
