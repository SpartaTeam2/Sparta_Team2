using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioClip mainbgm;

    [Header("Audio Source")]
    private AudioSource bgmSource;
    
    [SerializeField] private List<AudioSource> sfxSources = new List<AudioSource>();

    public int sfxMax = 20;
    public float defalutBgmVolume = 1.0f;
    public float defaultSfxVolume = 1.0f;
    private float saveBgm;
    private float saveSfx;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        bgmSource = gameObject.AddComponent<AudioSource>();
        bgmSource.loop = true;

        for (int i = 0; i < sfxMax; i++)
        {
            AudioSource sfx = gameObject.AddComponent<AudioSource>();
            sfxSources.Add(sfx);
        }

        bgmSource.volume = defalutBgmVolume;
        foreach (AudioSource sfx in sfxSources)
        {
            sfx.volume = defaultSfxVolume;
        }

        LoadVolume();

    }

    private void Start()
    {
        PlayBgm(mainbgm);
    }

    public void IsMainBGM()
    {
        if (bgmSource.clip == mainbgm)
            return;
        else
        {
            StopBgm();
            PlayBgm(mainbgm);
        }
    }
    public void PlayBgm(AudioClip clip)
    {
        if (bgmSource.clip == clip)
            return;
        bgmSource.clip = clip;
        bgmSource.Play();
    }

    public void StopBgm()
    {
        bgmSource.Stop();
    }

    public void PlaySfx(AudioClip clip)
    {
        AudioSource empytsource = sfxSources.Find(source => !source.isPlaying);
        if (empytsource == null)
            return;

        empytsource.clip = clip;
        empytsource.PlayOneShot(clip);
    }

    public void SetBgmVolume(float volume)
    {
        bgmSource.volume = volume;
        saveBgm = volume;
    }

    public void SetSfxVolume(float volume)
    {
        foreach (AudioSource sfx in sfxSources)
        {
            sfx.volume = volume;
        }
        saveSfx = volume;
    }

    public void SaveVolume()
    {
        float bgm = saveBgm;
        float sfx = saveSfx;
        PlayerPrefs.SetFloat("BGMVolume", bgm);
        PlayerPrefs.SetFloat("SFXVolume", sfx);
        PlayerPrefs.Save();
    }

    private void LoadVolume()
    {
        defalutBgmVolume = PlayerPrefs.GetFloat("BGMVolume", 1f);
        defaultSfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        SetBgmVolume(defalutBgmVolume);
        SetSfxVolume(defaultSfxVolume);
    }
}
