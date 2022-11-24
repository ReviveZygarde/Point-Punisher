using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOverMenu : MonoBehaviour
{
    // The GameOver script will assume that the globalStats_Player singleton is active.
    // If it doesn't exist when entering the scene (which shouldn't happen), the game will softlock
    // with a Null Exception.

    public Button returnToTitle;
    public Text stage;
    public Text points;
    private globalStats_player stats;

    void Start()
    {
        retreievePlayerStatSingleton();
        stage.text = stats.stageNumber;
        points.text = $"{stats.Points}";
        returnToTitle.onClick.AddListener(titleScreen);
    }

    private void retreievePlayerStatSingleton()
    {
        GameObject common = GameObject.Find("common");
        stats = common.GetComponent<globalStats_player>();
    }


    public void titleScreen()
    {
        GameObject common = GameObject.Find("common");
        Destroy(common);
        GameObject modeGO = GameObject.Find("!!!GAME_MODE_SELECTION");
        Destroy(modeGO);
        //When going back to the title screen, the "common" gameObject that carries the Singleton gets destroyed. (but gets reinstantiated when going to a stage)
        SceneManager.LoadScene("titleScreen");
    }
}
