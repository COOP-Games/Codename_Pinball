using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //config params
    [Range(0f,1f)] [SerializeField] 
    private float gameSpeed = 1f;
    
    [SerializeField] 
    private int pointsPerBlockDestroyed = 42;
    
    [SerializeField] 
    private TextMeshProUGUI scoreText;
    
    [SerializeField] 
    private bool isAutoPlayEnabled = false;

    // state variables
    [SerializeField] 
    private int P1Score = 0;

    [SerializeField] 
    private int P2Score = 0;

    private void Awake()
    {
        // Singleton
        int gameManagerCount = FindObjectsOfType<GameManager>().Length;
        if(gameManagerCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
        scoreText.SetText(P1Score.ToString());
    }
	
	// Update is called once per frame
	void Update ()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        P1Score += pointsPerBlockDestroyed;
        scoreText.SetText(P1Score.ToString());
    }

    public void Reset()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
