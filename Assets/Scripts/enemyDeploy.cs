using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class enemyDeploy : MonoBehaviour
{
    /// <summary>
    /// The enemyDeplot script is for "trigger lines" in the scene.
    /// Since I don't want all the enemies to start moving at the same time, I want to keep the enemy spawns controlled,
    /// so the enemy LEADER (not its followers) are enabled when the player collides with the "line" and the enemies start
    /// to move. The followers stay enabled, but their leaders are kept disabled until the "trigger line" is touched by the
    /// player and then the enemies can move into the camera's view.
    /// 
    /// As for the followers, do not panic if there's a Null exception when the scene starts. It just means that the followers
    /// are stuck and cannot find a leader because the leader is disabled in the first place, hence the name of the script, "enemyDeploy."
    /// </summary>

    public GameObject enemyLeaderToEnable;
    public bool shouldTheWallStop;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            enemyLeaderToEnable.SetActive(true);
            Debug.Log($"{enemyLeaderToEnable} has been ENABLED in the scene. It should spawn and start moving now.");
            if(shouldTheWallStop == true)
            {
                GameObject wallPush = GameObject.Find("wallPusher");
                wallPusherScript pushMechanic = wallPush.GetComponent <wallPusherScript>();
                Destroy(pushMechanic);
            }
        }
    }
}
