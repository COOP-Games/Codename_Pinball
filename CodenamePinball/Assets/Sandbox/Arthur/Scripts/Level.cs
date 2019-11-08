using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] 
    private int breakableBlocks = 0; //Serialized for debugging purposes
    
    [SerializeField] 
    private int unbreakableBlocks = 0;

    // cached reference
    private SceneLoader sceneloader;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }

    public void addOneBreakableBlock()
    {
        breakableBlocks++;
    }

    public void addOneUnbreakableBlock()
    {
        unbreakableBlocks++;
    }

    public void removeOneBreakableBlock()
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
            sceneloader.LoadNextScene();
        }
    }
}
