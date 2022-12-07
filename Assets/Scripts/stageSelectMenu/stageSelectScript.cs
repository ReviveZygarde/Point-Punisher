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
    public Button addLife;
    public Button removeLife;
    public Button addHP;
    public Button removeHP;
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
        addLife.onClick.AddListener(plusLife);
        removeLife.onClick.AddListener(minusLife);
        addHP.onClick.AddListener(plusHP);
        removeHP.onClick.AddListener(minusHP);
    }

    void SetStageStagetoNONE()
    {
        stats = common.GetComponent<globalStats_player>();
        stats.stageState = globalStats_player.currentStage.NONE;
        stats.stageNumber = "---";
    }

    void stage1start()
    {
        SceneManager.LoadScene("stage1_freeplay");
        stats.stageNumber = "Stage 1\n(Free Play)";
    }

    void stage2start()
    {
        SceneManager.LoadScene("stage2");
        stats.stageNumber = "Stage 2\n(Free Play)";
    }

    void stage3start()
    {
        SceneManager.LoadScene("stage3");
        stats.stageNumber = "Stage 3\n(Free Play)";
    }

    void stage4start()
    {
        SceneManager.LoadScene("stage4");
        stats.stageNumber = "Stage 4\n(Free Play)";
    }

    void toTitle()
    {
        Destroy(common);
        Destroy(mode);
        SceneManager.LoadScene("titleScreen");
    }

    //-----------------------------------------

    void plusLife()
    {
        if (stats.Lives < 5)
        {
            stats.sound.starSoundEffect();
            stats.Lives++;
        }
    }

    void minusLife()
    {
        if (stats.Lives > 0)
        {
            stats.sound.starSoundEffect();
            stats.Lives--;
        }
    }

    void plusHP()
    {
        if (stats.HP < 100)
        {
            stats.sound.starSoundEffect();
            stats.HP = stats.HP + 10;
        }
    }

    void minusHP()
    {
        if (stats.HP >= 60)
        {
            stats.sound.starSoundEffect();
            stats.HP = stats.HP - 10;
        }
    }

}
