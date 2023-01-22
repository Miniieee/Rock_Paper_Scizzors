using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class LoadScenesManagger : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject scoreCanvas;
    [SerializeField] GameObject xButtonClicked;
    [SerializeField] GameObject audioButtonEnabled;
    [SerializeField] GameObject audioButtonDisabled;
    [SerializeField] GameObject optionsPanel;

    [SerializeField] Button pauseButton;

    [SerializeField] Score reviveButton;

    [SerializeField] AudioSource audioSourceBackground;

    [SerializeField] AudioManagger audioManager;

    [SerializeField] AudioMixer volume;

    [SerializeField] Options soundOptionsLoad;

    float startMaster;
    float startMusic;
    float startButton;

    public void Start()
    {

        if (PlayerPrefs.GetFloat("mute", 1f) > 0)
        {
            audioSourceBackground.volume = 1;
            ButtonSoundMax();
            audioButtonEnabled.SetActive(true);
            audioButtonDisabled.SetActive(false);
        }
        else
        {
            audioSourceBackground.volume = 0;
            ButtonSoundMute();
            audioButtonEnabled.SetActive(false);
            audioButtonDisabled.SetActive(true);
        }

        startMaster = PlayerPrefs.GetFloat("master", 0f);
        startMusic = PlayerPrefs.GetFloat("music", 0f);
        startButton = PlayerPrefs.GetFloat("button", 0f);

        volume.SetFloat("master", startMaster);
        volume.SetFloat("music", startMusic);
        volume.SetFloat("button", startButton);

        soundOptionsLoad.MethodToLoadAtStart();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        scoreCanvas.SetActive(true);
        pauseButton.interactable=false;
    }

    public void PauseButtonClick()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        scoreCanvas.SetActive(true);
        ButtonClickSound();
    }

    public void ResumeButtonClick()
    {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        scoreCanvas.SetActive(false);
        ButtonClickSound();
    }

    public void RestartButtonClick()
    {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        scoreCanvas.SetActive(false);
        PlayerPrefs.SetInt("currentScore", 0);
        ButtonClickSound();
        SceneManager.LoadScene(1);
    }

    public void MainMenuButton()
    {
        ButtonClickSound();
        PlayerPrefs.SetInt("currentScore", 0);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ReviveButtonClick()
    {
        reviveButton.IfGunEnough();
        ButtonClickSound();
    }

    public void Revive()
    {
        SceneManager.LoadScene(1);
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        scoreCanvas.SetActive(false);
        pauseButton.interactable = true;
        Time.timeScale = 1;
    }

    public void XButtonClicked()
    {
        xButtonClicked.SetActive(false);
        ButtonClickSound();
    }

    public void MuteAudioClick()
    {
        audioSourceBackground.volume = 0;
        PlayerPrefs.SetFloat("mute", 0f);
        audioButtonEnabled.SetActive(false);
        audioButtonDisabled.SetActive(true);
        ButtonSoundMute();
    }

    public void EnableAudioClick()
    {
        audioSourceBackground.volume = 1;
        PlayerPrefs.SetFloat("mute", 1f);
        audioButtonEnabled.SetActive(true);
        audioButtonDisabled.SetActive(false);
        ButtonSoundMax();
    }

    #region Main menu buttons -----------------------------------------------------------------------------------------------------

    public void StartButonClick()
    {
        PlayerPrefs.SetInt("currentScore", 0);
        SceneManager.LoadScene(1);
        ButtonClickSound();
    }

    public void ExitButtonClick()
    {
        ButtonClickSound();
        Application.Quit();
    }

    public void OptionsMenuShow()
    {
        optionsPanel.SetActive(true);
    }

    public void OptionsMenuClos()
    {
        optionsPanel.SetActive(false);
    }

    #endregion --------------------------------------------------------------------------------------------------------------------


    private void ButtonClickSound()
    {
        audioManager.Play("ButtonClick");
    }

    private void ButtonSoundMute()
    {
        audioManager.MuteButtonclickSound("ButtonClick");
        audioManager.MuteButtonclickSound("Lose");
        audioManager.MuteButtonclickSound("Ok");
    }

    private void ButtonSoundMax()
    {
        audioManager.MaxButtonclickSound("ButtonClick");
        audioManager.MaxButtonclickSound("Lose");
        audioManager.MaxButtonclickSound("Ok");
    }

}
