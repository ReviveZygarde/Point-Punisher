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

    // Start is called before the first frame update
    void Start()
    {
        normalPlayStartButton.onClick.AddListener(startStage1);
        //gamerModeStartButton.onClick.AddListener(startStage1asGamerMode);
        //levelSelectButton.onClick.AddListener(goToLevelSelectMenu);
    }

    private void Update()
    {

    }

    public void startStage1()
    {
        SceneManager.LoadScene("stage1");
    }
}
