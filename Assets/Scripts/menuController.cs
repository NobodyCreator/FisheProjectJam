using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class menuController : MonoBehaviour
{

    public GameObject mainMenu, savesMenu, settingsMenu, currentMenu, previousMenu, playButton, settingsButton, quitButton, backButtonSettings, backButtonSaves;

    public Sprite[] clickAnimationSprites;

    // Start is called before the first frame update
    void Start()
    {

        // Retrieve user settings

        AudioListener.volume = PlayerPrefs.GetFloat("volume");

        GameObject.Find("volume").GetComponent<Slider>().value = AudioListener.volume;

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

        // Initialize the main menu

        currentMenu = mainMenu;
        settingsMenu.SetActive(false);
        savesMenu.SetActive(false);

    }

    IEnumerator clickAnimate(GameObject clickedButton, GameObject menuToOpen) {

        clickedButton.GetComponent<Button>().interactable = false;

        for (int i = 0; i < clickAnimationSprites.Length; i++)
        {

            clickedButton.GetComponent<Image>().overrideSprite = clickAnimationSprites[i];
            yield return new WaitForSeconds(0.02f);

        }

        if (string.Compare(clickedButton.name, "quitButton") == 0)
        {
            Application.Quit();
        }

        clickedButton.GetComponent<Button>().interactable = true;

        changeMenu(menuToOpen);
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

        StartCoroutine(clickAnimate(playButton, savesMenu));
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

    public void changeVolume(System.Single vol)
    {

        PlayerPrefs.SetFloat("volume", vol);
        AudioListener.volume = PlayerPrefs.GetFloat("volume");

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

}
