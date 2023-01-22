using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    [SerializeField] GameObject audioButtonEnabled;
    [SerializeField] GameObject audioButtonDisabled;

    [SerializeField] Slider masterSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider buttonSlider;
    [SerializeField] AudioMixer volume;

    float startMaster;
    float startMusic;
    float startButton;

    public void Start()
    {
        MethodToLoadAtStart();
    }

    public void MethodToLoadAtStart()
    {
        startMaster = PlayerPrefs.GetFloat("master", 0f);
        startMusic = PlayerPrefs.GetFloat("music", 0f);
        startButton = PlayerPrefs.GetFloat("button", 0f);

        volume.SetFloat("master", startMaster);
        volume.SetFloat("music", startMusic);
        volume.SetFloat("button", startButton);

        print("betolti");

        masterSlider.value = startMaster;
        musicSlider.value = startMusic;
        buttonSlider.value = startButton;

        if (PlayerPrefs.GetFloat("mute", 1f) > 0)
        {
            audioButtonEnabled.SetActive(true);
            audioButtonDisabled.SetActive(false);
        }
        else
        {
            audioButtonEnabled.SetActive(false);
            audioButtonDisabled.SetActive(true);
        }
    }

    public void MasterSlider(float master)
    {
        PlayerPrefs.SetFloat("master", master);
        volume.SetFloat("master", master);
    }

    public void MusicSlider(float music)
    {
        PlayerPrefs.SetFloat("music", music);
        volume.SetFloat("music", music);
    }

    public void ButtonSlider(float button)
    {
        PlayerPrefs.SetFloat("button", button);
        volume.SetFloat("button", button);
    }
}
