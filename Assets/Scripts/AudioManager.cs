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
        if (sliderBGM != null) sliderBGM.value = audioSourceBGM.volume;
        if (sliderSFX != null) sliderSFX.value = audioSourceSFX.volume;

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


    public void SetBGM(AudioClip value)
    {
        if (audioSourceBGM.clip == value) return;

        if (value == mainmenuBgm)
        {
            audioSourceBGM.clip = mainmenuBgm;
            audioSourceBGM.Play();
        }
        else if (value == gameplayBgm)
        {
            audioSourceBGM.clip = gameplayBgm;
            audioSourceBGM.Play();
        }
        else
        {
            Debug.Log("Missing Audio : " + value);
        }
    }
    [Header("SFX")]
    public AudioClip SFXExp;
    public AudioClip SFXClickButton;
    public AudioClip SFXPiscok;
    public AudioClip SFXBregedeg;
    public AudioClip SFXBasokha;
    public AudioClip SFXPlayerWalk;
    public AudioClip SFXFail;
    public AudioClip SFXComplete;
    public AudioClip SFXSignal;

    bool cdExp;
    public void SetSFX(AudioClip value)
    {
        if (value == SFXExp)
        {
            if (cdExp) return;
            cdExp = true;
            audioSourceSFX.PlayOneShot(SFXExp);

            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                yield return new WaitForSeconds(0.5f);
                cdExp = false;
            }
        }
        else if (value == SFXComplete)
        {
            audioSourceSFX.PlayOneShot(SFXComplete);
        }
        else if (value == SFXPiscok)
        {
            audioSourceSFX.PlayOneShot(SFXPiscok);
        }
        else if (value == SFXBregedeg)
        {
            audioSourceSFX.PlayOneShot(SFXBregedeg);
        }
        else if (value == SFXBasokha)
        {
            audioSourceSFX.PlayOneShot(SFXBasokha);
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
