using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuController : MonoBehaviour
{

    GameObject mainMenu, savesMenu, settingsMenu, currentMenu, previousMenu, playButton, settingsButton, quitButton, backButtonSettings, backButtonSaves;

    public Sprite[] clickAnimationSprites;

    // Start is called before the first frame update
    void Start()
    {

        mainMenu = GameObject.Find("mainMenu");
        settingsMenu = GameObject.Find("settingsMenu");
        savesMenu = GameObject.Find("savesMenu");

        playButton = GameObject.Find("playButton");
        settingsButton = GameObject.Find("settingsButton");
        quitButton = GameObject.Find("quitButton");
        backButtonSettings = GameObject.Find("backButtonSettings");
        backButtonSaves = GameObject.Find("backButtonSaves");

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


}
