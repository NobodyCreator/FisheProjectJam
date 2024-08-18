using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class menuController : MonoBehaviour
{

    public GameObject mainMenu, settingsMenu, currentMenu, previousMenu, pauseMenu, playButton, settingsButton, quitButton, backButtonSettings, backButtonSaves;

    public Boolean pause, paused;

    public Sprite[] clickAnimationSprites;

    // Start is called before the first frame update
    void Start()
    {

        // Retrieve user settings

        if (String.Compare(PlayerPrefs.GetString("fullscreen"), "true") == 0)
        {
            GameObject.Find("fullscreenToggle").GetComponent<Toggle>().isOn = true;
            Screen.SetResolution(Display.main.systemWidth, Display.main.systemHeight, FullScreenMode.FullScreenWindow);
        }
        else
        {
            GameObject.Find("fullscreenToggle").GetComponent<Toggle>().isOn = false;
            Screen.SetResolution(1080, 720, false);
        }

        // Initialize the relevant menu

        if(pause == true)
        {

            currentMenu = pauseMenu;
            pauseMenu.SetActive(false);
            settingsMenu.SetActive(false);

        }
        else
        {

            currentMenu = mainMenu;
            settingsMenu.SetActive(false);

        }

    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {

            if (paused == false)
            {
                clickPause();
            }
            else
            {
                clickUnpause();
            }

        }

    }

    IEnumerator clickAnimate(GameObject clickedButton, GameObject menuToOpen) {

        clickedButton.GetComponent<Button>().interactable = false;

        for (int i = 0; i < clickAnimationSprites.Length; i++)
        {

            clickedButton.GetComponent<Image>().overrideSprite = clickAnimationSprites[i];
            yield return new WaitForSecondsRealtime(0.02f);

        }

        if (string.Compare(clickedButton.name, "quitButton") == 0)
        {
            Application.Quit();
        }
        else if ((string.Compare(clickedButton.name, "playButton") == 0) && pause == true)      
        {
            clickedButton.GetComponent<Button>().interactable = true;
            unpause();
        }
        else
        {
            clickedButton.GetComponent<Button>().interactable = true;

            changeMenu(menuToOpen);
        }

    }

    void changeMenu(GameObject menuToOpen)
    {

        // Hide the current menu and store it in previous menu

        currentMenu.SetActive(false);
        previousMenu = currentMenu;


        // Display new menu and save it as current menu

        menuToOpen.SetActive(true);
        currentMenu = menuToOpen;
    }
    public void clickPlay()
    {

        // Play animation

        StartCoroutine(clickAnimate(playButton, mainMenu));
    }
    public void clickSettings() {

        // Play animation

        StartCoroutine(clickAnimate(settingsButton, settingsMenu));

    }

    public void clickBack() {

        // Play animation

        if(settingsMenu.activeSelf == true)
        {
            StartCoroutine(clickAnimate(backButtonSettings, mainMenu));
        }
        else
        {
            StartCoroutine(clickAnimate(backButtonSaves, mainMenu));
        }


    }

    public void clickQuit() {

        // Play animation

        StartCoroutine(clickAnimate(quitButton, mainMenu));

    }

    public void changeFullscreen(System.Boolean toggle)
    {

        if (toggle == true)
        {
            Screen.SetResolution(Display.main.systemWidth, Display.main.systemHeight, FullScreenMode.FullScreenWindow);
            PlayerPrefs.SetString("fullscreen", "true");
        }
        else
        {
            Screen.SetResolution(1080, 720, false);
            PlayerPrefs.SetString("fullscreen", "false");
        }

    }

    public void clickPause()
    {

        paused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        AudioListener.pause = true;

    }

    public void clickUnpause()
    {

        StartCoroutine(clickAnimate(playButton, pauseMenu));

    }

    public void unpause()
    {
        paused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        AudioListener.pause = false;
    }

}
