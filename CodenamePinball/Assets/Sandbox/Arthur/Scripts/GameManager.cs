using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour
{
    //config params
    [Range(0f, 1f)]
    [SerializeField]
    private float gameSpeed = 1f;

    [SerializeField]
    private bool isAutoPlayEnabled = false;

    [SerializeField]
    private int pointsPerBlockDestroyed = 42;

    [SerializeField]
    private TextMeshProUGUI p1ScoreText;

    [SerializeField]
    private TextMeshProUGUI p2ScoreText;

    // state variables
    [SerializeField]
    private int P1Score = 0;

    [SerializeField]
    private int P2Score = 0;

    [SerializeField]
    private int levelsUnlocked = 0;

    private void Awake()
    {
        // Singleton
        int gameManagerCount = FindObjectsOfType<GameManager>().Length;
        if (gameManagerCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        p1ScoreText.SetText(P1Score.ToString());
        p2ScoreText.SetText(P2Score.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToP1Score()
    {
        P1Score += pointsPerBlockDestroyed;
        p1ScoreText.SetText(P1Score.ToString());
    }

    public void AddToP2Score()
    {
        P2Score += pointsPerBlockDestroyed;
        p2ScoreText.SetText(P2Score.ToString());
    }

    public void Reset()
    {
        // TODO Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();

        save.levelProgress = levelsUnlocked;

        return save;
    }

    public void SaveGame()
    {
        // Create a Save instance with all the data for the current session saved into it
        Save save = CreateSaveGameObject();

        SaveAsBinary(save);
        SaveAsJSON(save);

        Debug.Log("GAME SAVED");
    }

    private void SaveAsBinary(Save save)
    {
        // Create a BinaryFormatter and a FileStream by passing a 
        // path for the Save instance to be saved to
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        Debug.Log("SAVING AS BINARY");
    }

    private void SaveAsJSON(Save save)
    {
        string json = JsonUtility.ToJson(save);

        Debug.Log("SAVING AS JSON");
        // Debug.Log("SAVING AS JSON" + json);
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            levelsUnlocked = save.levelProgress;

            Debug.Log("GAME LOADED");
        }
        else
        {
            Debug.Log("No Game Saved!");
        }
    }

    public void UnlockLevel()
    {
        levelsUnlocked++;
        SaveGame();
    }

    public int GetLevelsUnlocked()
    {
        return levelsUnlocked;
    }
}
