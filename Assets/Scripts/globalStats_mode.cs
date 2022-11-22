using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class globalStats_mode : Singleton<globalStats_player>
{
    //This is gonna be a singleton that keeps track of your records as you play through the games and the different scenes.

    /// <summary>
    /// Stores a state machine wether or not you are going through levels in order or are going through level select.
    /// NORMAL = Normal game mode.
    /// GAMER_MODE = Hard difficulty. You start with 1 life left, but points increase drastically, Risk/reward type beat.
    /// FREE_PLAY = user selected a level from level select.
    /// </summary>
    public enum gameMode
    { NORMAL, GAMER_MODE, FREE_PLAY}
    public gameMode selectedMode = gameMode.NORMAL;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}