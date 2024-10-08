using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuScript : MonoBehaviour
{
    public Button closeButton;
    public Button openButton;
    public Slider volSlider;
    public GameObject menuRoot;
    public AudioMixer audioMixer;
    public bool gamePaused = false;

    void Awake()
    {
        closeButton.onClick.AddListener(CloseMenu);
        openButton.onClick.AddListener(OpenMenu);
        volSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) & gamePaused)
        {
            
            CloseMenu();
        }
    }
    

    void CloseMenu()
    {
        openButton.gameObject.SetActive(true);
        menuRoot.SetActive(false);
        ResumeGame();
    }
    public void OpenMenu()
    {
        menuRoot.SetActive(true);
        openButton.gameObject.SetActive(false);
        PauseGame();
    }
    void OnVolumeChanged(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    void PauseGame() 
    { 
        gamePaused = true;
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        gamePaused = false;
        Time.timeScale = 1;
    }
}
