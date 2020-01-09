using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// keep track of game saves
[System.Serializable]
public class Save
{
    // a int number to indicate what is the game level the player currently unlocked
    public int levelProgress = 0;

    // TODO is there any other game attributes that we want to save?
    // TODO maybe create a map to indicate the player high scores in every scenario?
}
