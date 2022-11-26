using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class globalStats_player : Singleton<globalStats_player>
{
    //This is gonna be a singleton that keeps track of your records as you play through the games and the different scenes.

    /// <summary>
    /// stageNumber, pointsNumber, and livesNumber are relating to the (old) UI.
    /// </summary>
    public Text stageNumberForUI;
    public Text pointsNumber;
    public Text livesNumber;
    public Text currentHP;
    private globalStats_mode selectedMode;
    public GameObject blackScreenForDeath;

    //UI buttons for testing purposes
    public Button forceRestartStage;
    public Button skipToStageClear;

    /// <summary>
    /// Stores Default HP, Score Points and Lives.
    /// </summary>
    public string stageNumber = "Stage 1";
    public int Points = 0;
    public int Lives = 5;
    public int HP = 100;
    public int starsCollected = 0;

    /// <summary>
    /// Sound effect related.
    /// </summary>
    public soundManager sound;


    /// <summary>
    /// Used for the event system during gameplay.
    /// NO_EVENT_HAPPENING = No event is happening.
    /// ADD_LIFE = Player picked up an item that increases a Life.
    /// PLAYER_DEAD = Player died and lost a life. If the player has 0 lives left -> send to Game Over scene.
    /// LEVEL_COMPLETED = Completed a level.
    /// LOW_HP = Low HP. If the HP is under 25.
    /// Depending on gameMode state, switch to their respective scene
    /// (NORMAL/GAMER -> to the next level, or FREE PLAY -> lvl select scene.)
    /// </summary>
    enum playerGameplayStatus
    { NO_EVENT_HAPPENING, ADD_LIFE, PLAYER_DEAD, LEVEL_COMPLETED}
    playerGameplayStatus importantEvent = playerGameplayStatus.NO_EVENT_HAPPENING;

    public enum currentStage
    { STAGE1, STAGE2, STAGE3, STAGE4, NONE} // NONE is for Level Select.
    public currentStage stageState = currentStage.STAGE1;


    private void Start()
    {
        forceRestartStage.onClick.AddListener(restartStageAfterDeath);
        skipToStageClear.onClick.AddListener(toStageClearScreen);
    }

    private void OnEnable()
    {
        stageNumberForUI.text = stageNumber;
        fetchGameModeSingleton();
    }

    void fetchGameModeSingleton()
    {
        GameObject gameModeObject = GameObject.Find("!!!GAME_MODE_SELECTION");
        selectedMode = gameModeObject.GetComponent<globalStats_mode>();
    }

    // Update is called once per frame
    void Update()
    {
        pointsNumber.text = $"{Points}";
        livesNumber.text = $"{Lives}";
        currentHP.text = $"{HP}";
        if(HP <= 30)
        {
            sound.lowHPalarmPlayback();
        }
        if(HP > 30)
        {
            sound.lowHPalarmStop();
        }
        if(HP <= 0)
        {
            restartStageAfterDeath();
        }
    }

    void restartStageAfterDeath() //After the player's HP reaches 0, restart scene and bring the HP back up to 100.
    {
        if(Lives > 0)
        {
            sound.deathSoundPlay();
            Lives = Lives - 1;
            HP = 100;
            starsCollected = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene("gameOverScene");
        }
    }

    public void toStageClearScreen()
    {
        HP = 100;
        SceneManager.LoadScene("stage1results");
    }

}
