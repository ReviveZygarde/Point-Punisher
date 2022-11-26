using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallPusherScript : MonoBehaviour
{
    private globalStats_mode mode;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gm_obj = GameObject.Find("!!!SELECTED_GAME_MODE");
        mode = gm_obj.GetComponent<globalStats_mode>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, 0, 0.003f);
    }
}
