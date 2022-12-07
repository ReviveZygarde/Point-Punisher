using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyboxRotate : MonoBehaviour
{

    // Update is called once per frame
    //From https://stackoverflow.com/questions/51387887/how-to-make-this-skybox-rotate-unity
    void Update()
    {
      RenderSettings.skybox.SetFloat("_Rotation", Time.time * -0.4f);
    }
}
