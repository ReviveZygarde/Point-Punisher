using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class titleMenu : MonoBehaviour
{
    public Button normalPlayStartButton;
    public Button gamerModeStartButton;
    public Button levelSelectButton;
    public Button how2playButton;
    public globalStats_mode userModeSelection;
    private soundManager sound;

    // Start is called before the first frame update
    void Start()
    {
        userModeSelection.selectedMode = globalStats_mode.gameMode.NORMAL;
        sound = this.GetComponent<soundManager>();
        normalPlayStartButton.onClick.AddListener(startNormal);
        gamerModeStartButton.onClick.AddListener(startAsGamerMode);
        levelSelectButton.onClick.AddListener(goToStageSelectMenu);
        how2playButton.onClick.AddListener(goToHow2playScreen);
    }

    public void startNormal()
    {
        userModeSelection.selectedMode = globalStats_mode.gameMode.NORMAL;
        startStage1();
    }

    public void startAsGamerMode()
    {
        userModeSelection.selectedMode = globalStats_mode.gameMode.GAMER_MODE;
        startStage1();
    }

    public void startStage1()
    {
        SceneManager.LoadScene("stage1");
        Debug.Log("Game Mode (difficulty) change is not implemented yet, so either option is the same thing for now.");
    }

    public void goToStageSelectMenu()
    {
        userModeSelection.selectedMode = globalStats_mode.gameMode.FREE_PLAY;
        SceneManager.LoadScene("stageSelect");
    }

    public void goToHow2playScreen()
    {
        //SceneManager.LoadScene("controls_screen");
        sound.errorPlay();
        Debug.Log("Not implemented yet.");
    }


}
