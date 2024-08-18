using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class audioManager : MonoBehaviour
{

    public AudioMixer audioMixer;

    public GameObject musicVolumeSlider, soundEffectVolumeSlider;

    // Start is called before the first frame update
    void Start()
    {

        musicVolumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("musicVolume");
        audioMixer.SetFloat("Music", PlayerPrefs.GetFloat("musicVolume"));

        soundEffectVolumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("soundEffectVolume");
        audioMixer.SetFloat("Sound Effects", PlayerPrefs.GetFloat("soundEffectVolume"));

    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void changeMusicVolume(float volume)
    {
        if(volume <= 0f)
        {
            audioMixer.SetFloat("Music", -80f);
            PlayerPrefs.SetFloat("musicVolume", -80f);

        }
        else
        {

            audioMixer.SetFloat("Music", volume);
            PlayerPrefs.SetFloat("musicVolume", volume);

        }

    }

    public void changeSoundsVolume(float volume)
    {
        if (volume <= 0f)
        {
            audioMixer.SetFloat("Sound Effects", -80f);
            PlayerPrefs.SetFloat("soundEffectVolume", -80f);

        }
        else
        {

            audioMixer.SetFloat("Sound Effects", volume);
            PlayerPrefs.SetFloat("soundEffectVolume", volume);
        }


    }
}
