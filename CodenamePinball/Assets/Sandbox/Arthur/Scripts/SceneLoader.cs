using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;//faz a variavel guardar o indice da cena atual de jogo
        SceneManager.LoadScene(currentSceneIndex + 1);//chama a função de carregar uma cena e passa como parametro o indice atual + 1 para ir para próxima cena
    }

    public void FirstScreen()
    {
        gameManager.Reset();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(int level_index)
    {
        // string levelName = "Assets/Scenes/Level_" + level_index + ".unity";
        // string levelName = "Assets/Scenes/Level_00.unity";
        string levelName = "Level_"+level_index;
        Debug.Log("Level: " + levelName);

        SceneManager.LoadScene(levelName,LoadSceneMode.Single);
    }
}

