using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_Menu : MonoBehaviour
{
    [SerializeField]
    private Button[] main_menu_buttons;

    [SerializeField]
    private Button[] options_menu_buttons;

    [SerializeField]
    private Button[] campaign_menu_buttons;

    [SerializeField]
    private Image[] background_images;

    [SerializeField]
    private AudioClip[] sounds;

    private bool is_campaign_buttons_active;
    private bool is_options_buttons_active;

    // Cached reference
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.LoadGame();
        StartState();
    }

    /** Load the level selected by the player */
    public void LoadLevel()
    {

    }

    private void StartState()
    {
        is_campaign_buttons_active = false;
        is_options_buttons_active = false;

        for (int i = 0; i < options_menu_buttons.Length; i++)
        {
            options_menu_buttons[i].gameObject.SetActive(false);
        }
        is_options_buttons_active = false;

        for (int i = 1; i < campaign_menu_buttons.Length; i++)
        {
            campaign_menu_buttons[i].gameObject.SetActive(false);
            
            if(i <= gameManager.GetLevelsUnlocked())
            {
                campaign_menu_buttons[i].interactable = true;
            }else
            {
                campaign_menu_buttons[i].interactable = false;
            }
        }
        is_campaign_buttons_active = false;

        for (int i = 0; i < main_menu_buttons.Length; i++)
        {
            main_menu_buttons[i].gameObject.SetActive(true);
        }
    }
    /** Return to the first screen */
    public void MainMenu()
    {
        if (is_options_buttons_active)
        {
            for (int i = 0; i < options_menu_buttons.Length; i++)
            {
                options_menu_buttons[i].gameObject.SetActive(false);
            }
            is_options_buttons_active = false;
        }

        if (is_campaign_buttons_active)
        {
            for (int i = 0; i < campaign_menu_buttons.Length; i++)
            {
                campaign_menu_buttons[i].gameObject.SetActive(false);
            }
            is_campaign_buttons_active = false;
        }

        for (int i = 0; i < main_menu_buttons.Length; i++)
        {
            main_menu_buttons[i].gameObject.SetActive(true);
        }
    }

    /** Load the campaign screen */
    public void CampaignMenu()
    {
        for (int i = 0; i < main_menu_buttons.Length; i++)
        {
            main_menu_buttons[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < campaign_menu_buttons.Length; i++)
        {
            campaign_menu_buttons[i].gameObject.SetActive(true);
        }
        is_campaign_buttons_active = true;

        CheckUnlockedLevels();
    }

    /** Load the options screen */
    public void OptionsMenu()
    {
        for (int i = 0; i < main_menu_buttons.Length; i++)
        {
            main_menu_buttons[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < options_menu_buttons.Length; i++)
        {
            options_menu_buttons[i].gameObject.SetActive(true);
        }
        is_options_buttons_active = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void CheckUnlockedLevels()
    {
        
    }
}
