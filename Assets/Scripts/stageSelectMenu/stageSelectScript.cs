using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class stageSelectScript : MonoBehaviour
{
    public Button stage1button;
    public Button stage2button;
    public Button stage3button;
    public Button stage4button;
    public Button back;
    private GameObject common;
    private GameObject mode;
    private globalStats_player stats;

    // Start is called before the first frame update
    void Start()
    {
        common = GameObject.Find("common");
        mode = GameObject.Find("!!!GAME_MODE_SELECTION");
        SetStageStagetoNONE();
        back.onClick.AddListener(toTitle);
        stage1button.onClick.AddListener(stage1start);
        stage2button.onClick.AddListener(stage2start);
        stage3button.onClick.AddListener(stage3start);
        stage4button.onClick.AddListener(stage4start);
    }

    void SetStageStagetoNONE()
    {
        stats = common.GetComponent<globalStats_player>();
        stats.stageState = globalStats_player.currentStage.NONE;
    }

    void stage1start()
    {

    }

    void stage2start()
    {

    }

    void stage3start()
    {

    }

    void stage4start()
    {

    }

    void toTitle()
    {
        Destroy(common);
        Destroy(mode);
        SceneManager.LoadScene("titleScreen");
    }

}