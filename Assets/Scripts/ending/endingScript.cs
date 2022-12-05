using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endingScript : MonoBehaviour
{
    public Text text;
    public Button button;
    private int finalPoints;
    private globalStats_player stat;

    // Start is called before the first frame update
    void Start()
    {
        GameObject common = GameObject.Find("common");
        stat = common.GetComponent<globalStats_player>();
        finalPoints = stat.Points;
        Destroy(common);
        StartCoroutine(changeText());
        button.onClick.AddListener(returnToTitle);
    }

    void returnToTitle()
    {
        GameObject GameModeObject = GameObject.Find("!!!GAME_MODE_SELECTION");
        Destroy(GameModeObject);
        SceneManager.LoadScene("titleScreen");
    }

    IEnumerator changeText()
    {
        yield return new WaitForSeconds(5f);
        text.text = "Point Punisher!! credits";
        yield return new WaitForSeconds(4f);
        text.text = "C# Program:\nAndrew Peterson";
        yield return new WaitForSeconds(4f);
        text.text = "Low-poly Spaceships Asset\nby Astronaut";
        yield return new WaitForSeconds(4f);
        text.text = $"BGM:\nStage music from Star Fox Assault\nTitle and Stage Select:\nYu-Gi-Oh! Forbidden Memories";
        yield return new WaitForSeconds(7f);
        text.text = $"Stage clear jingle:\nSonic CD";
        yield return new WaitForSeconds(7f);
        text.text = $"Duel Robo Character Sprite:\nYu-Gi-Oh! Eternal Duelist Soul";
        yield return new WaitForSeconds(7f);
        text.text = $"Your final score:\n{finalPoints}";
        yield return null;
    }
}
