using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/**
 This is a class to store settings in there such as the player’s graphic settings, or 
 login info (perhaps Facebook or Twitter tokens), and 
whatever other configuration settings make sense to keep track of for the player.
*/
public class PlayerSettings : MonoBehaviour
{
    [SerializeField]
    private Slider music_volume;

    [SerializeField]
    private Slider sfx_volume;

    [SerializeField]
    private AudioSource music_source;
    
    [SerializeField]
    private AudioSource sfx_source;

    private void Awake()
    {
        // Check if the PlayerPrefs has a cached setting for the “music” key
        CheckMusic();

        // Check if the PlayerPrefs has a cached setting for the “sfx” key
        CheckSFX();
    }

    private void CheckMusic()
    {
        if (!PlayerPrefs.HasKey("music"))
        {
            // If there is no value there, it creates a key-value pair for the music key with a value of 1
            PlayerPrefs.SetFloat("music", 1f);

            // set the audio volume to 1(max)
            music_source.volume = 1;

            // Set the slider value to 1(max)
            music_volume.normalizedValue = 1;

            PlayerPrefs.Save();
        }
        else
        {
            // set the audio volume to custom
            music_source.volume = PlayerPrefs.GetFloat("music");

            // Set the slider value to custom value
            music_volume.normalizedValue = PlayerPrefs.GetFloat("music");
        }
    }

    private void CheckSFX()
    {
        if (!PlayerPrefs.HasKey("sfx"))
        {
            // If there is no value there, it creates a key-value pair for the music key with a value of 1
            PlayerPrefs.SetFloat("sfx", 1f);

            // set the audio volume to 1(max)
            sfx_source.volume = 1;

            // Set the slider value to 1(max)
            sfx_volume.normalizedValue = 1;

            PlayerPrefs.Save();
        }
        else
        {
            // set the audio volume to custom
            sfx_source.volume = PlayerPrefs.GetFloat("sfx");

            // Set the slider value to custom value
            sfx_volume.normalizedValue = PlayerPrefs.GetFloat("sfx");
        }
    }

    // Method if the player changes the setting during gameplay
    public void SetMusicVolume()
    {
        // set the volume to the new value
        music_source.volume = music_volume.normalizedValue;

        // set the new value to player pref music
        PlayerPrefs.SetFloat("music", music_volume.normalizedValue);

        PlayerPrefs.Save();
    }

    // Method if the player changes the setting during gameplay
    public void SetSFXVolume()
    {
        // set the volume to the new value
        sfx_source.volume = sfx_volume.normalizedValue;

        // set the new value to player pref music
        PlayerPrefs.SetFloat("sfx", sfx_volume.normalizedValue);

        PlayerPrefs.Save();
    }
}
