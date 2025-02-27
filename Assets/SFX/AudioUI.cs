using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioUI : MonoBehaviour
{
    public Slider bgmVolume;
    public Slider sfxVolume;
    public Button saveButton;

    private void Start()
    {
        bgmVolume.value = PlayerPrefs.GetFloat("BGMVolume", AudioManager.Instance.defalutBgmVolume);
        sfxVolume.value = PlayerPrefs.GetFloat("SFXVolume", AudioManager.Instance.defaultSfxVolume);

        bgmVolume.onValueChanged.AddListener(AudioManager.Instance.SetBgmVolume);
        sfxVolume.onValueChanged.AddListener(AudioManager.Instance.SetSfxVolume);
    }

    public void Save()
    {
        AudioManager.Instance.SaveVolume();
    }
}
