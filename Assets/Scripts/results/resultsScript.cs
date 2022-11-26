using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class resultsScript : MonoBehaviour
{
    private globalStats_player playerStat;
    private globalStats_mode mode;
    private GameObject common;
    public int multiplerForGamerMode = 1;
    private int scoreAfterCalculation = 0;
    public Text score;
    public Text starsCollected;
    public Text scoreMultiplier;
    public Text finalScore;
    public Button nextButton;

    private void OnEnable()
    {
        fetchSingletons();
    }

    public void Start()
    {
        checkGameMode();
        score.text = "";
        starsCollected.text = "";
        scoreMultiplier.text = "";
        finalScore.text = "";
        StartCoroutine(calculationScreCoroutine());
        nextButton.onClick.AddListener(proceedToNextScene);
    }

    void checkGameMode()
    {
        switch (mode.selectedMode)
        {
            case globalStats_mode.gameMode.GAMER_MODE:
                if (mode.selectedMode == globalStats_mode.gameMode.GAMER_MODE)
                {
                    multiplerForGamerMode++;
                }
            break;
        }
    }

    void fetchSingletons()
    {
        common = GameObject.Find("common");
        GameObject mode_obj = GameObject.Find("!!!GAME_MODE_SELECTION");
        playerStat = common.GetComponent<globalStats_player>();
        mode = mode_obj.GetComponent<globalStats_mode>();
    }

    void proceedToNextScene()
    {
        playerStat.starsCollected = 0;
        if (mode.selectedMode == globalStats_mode.gameMode.FREE_PLAY)
        {
            SceneManager.LoadScene("stageSelect");
            Destroy(common);
        }
        else
        {
            stageStateMachineChange();
        }
    }

    void stageStateMachineChange()
    {
        switch (playerStat.stageState)
        {
            case globalStats_player.currentStage.STAGE1:
                if (playerStat.stageState == globalStats_player.currentStage.STAGE1)
                {
                    startStage2();
                }
                break;
            case globalStats_player.currentStage.STAGE2:
                if (playerStat.stageState == globalStats_player.currentStage.STAGE2)
                {
                    startStage3();
                }
                break;
            case globalStats_player.currentStage.STAGE3:
                if (playerStat.stageState == globalStats_player.currentStage.STAGE3)
                {
                    startStage4();
                }
                break;
            case globalStats_player.currentStage.STAGE4:
                if (playerStat.stageState == globalStats_player.currentStage.STAGE4)
                {
                    startEnding();
                }
                break;
            case globalStats_player.currentStage.NONE: //This may never be called, but lets keep it here in case the game mode singleton derps out.
                {
                    SceneManager.LoadScene("stageSelect");
                    Destroy(common);
                }
                break;
        }
    }

    void startStage2()
    {
        playerStat.stageState = globalStats_player.currentStage.STAGE2;
        playerStat.stageNumber = "Stage 2";
        SceneManager.LoadScene("stage2");
    }

    void startStage3()
    {
        playerStat.stageState = globalStats_player.currentStage.STAGE3;
        playerStat.stageNumber = "Stage 3";
        SceneManager.LoadScene("stage3");
    }

    void startStage4()
    {
        playerStat.stageState = globalStats_player.currentStage.STAGE4;
        playerStat.stageNumber = "Stage 4";
        SceneManager.LoadScene("stage4");
    }

    void startEnding()
    {
        playerStat.stageState = globalStats_player.currentStage.NONE;
        playerStat.stageNumber = "";
        SceneManager.LoadScene("endingScene");
    }


    IEnumerator calculationScreCoroutine()
    {
        yield return new WaitForSeconds(1);
        score.text = $"{playerStat.Points}";
        playerStat.sound.dingPlay();
        yield return new WaitForSeconds(1);
        starsCollected.text = $"{playerStat.starsCollected}";
        playerStat.sound.dingPlay();
        yield return new WaitForSeconds(1);
        scoreMultiplier.text = $"{playerStat.Points} Å~ {playerStat.starsCollected} Å~ {multiplerForGamerMode}";
        playerStat.sound.dingPlay();
        yield return new WaitForSeconds(3);
        scoreAfterCalculation = playerStat.Points * playerStat.starsCollected * multiplerForGamerMode;
        finalScore.text = $"{scoreAfterCalculation}";
        playerStat.Points = scoreAfterCalculation;
        playerStat.sound.starSoundEffect();
        yield return null;
    }
}
