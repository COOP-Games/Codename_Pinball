using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField]
    int maxHits = 3;

    // cached reference
    Level level;
    GameManager gameManager;

    // state variables
    [SerializeField] int timesHit = 0; //only serialized for debug purposes

    private void Start()
    {
        CountBlocks();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void CountBlocks()
    {
        level = FindObjectOfType<Level>();

        if (tag == "Breakable")
        {
            level.addOneBreakableBlock();
        }
        else if (tag == "Unbreakable")
        {
            level.addOneUnbreakableBlock();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;

        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        Destroy(gameObject);//destroi o objeto
        gameManager.AddToScore(); // aumenta a pontuacao do jogador
        level.removeOneBreakableBlock(); // diminui em 1 o numero total de blocos da fase
    }
}
