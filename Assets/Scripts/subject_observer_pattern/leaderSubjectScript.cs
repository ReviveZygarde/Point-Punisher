using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class leaderSubjectScript : Subject
{
    public string enemyGroupTag; //This is the HUGE game changer here. I can use the Inspector
                                 //to change tags of groups of enemies in bulk, and use that tag
                                 //here for the leader of the mob. Since levels are in different scenes
                                 //instead of just 1, the tags will be less cluttered in terms of organization.
    private Array followerCapsulesArray;

    /// <summary>
    /// TODO:
    /// 1. When one of the Followers are destroyed, the remaining followers behind it are frozen. I need to find a way to
    /// fix this.
    /// 
    /// 2. When the leader capsule is destroyed, I need the 1st enemy in the followerCapsulesArray to become the new leader/subject or else the Followers
    /// also freeze. Also need to make the next one in the array become the leader if the preceding one in the array gets destroyed.
    /// 
    /// 3. If number 2 is done, next I need to attach a new leaderSubject script to the next enemy in followerCapsulesArray if the
    /// temporal leader is destroyed. To become the new Leader, delete the Follower script from it, and also move ALL of its EnemyBehavior
    /// variables from the previous leader to the next as well.(That's why I leave the EnemyBehavior and NavMeshAgent components intact
    /// for now... so ignore the errors in the Debug Log)
    /// 
    /// </summary>

    private void Update()
    {
        NotifyObservers();
    }
    
    private void OnEnable()
    {
        enableAction();
    }

    private void enableAction()
    {
        followerCapsulesArray = GameObject.FindGameObjectsWithTag(enemyGroupTag); //Find capsules that are in the scene already.
        foreach (GameObject capsule in followerCapsulesArray) //Adds a Follower to the Enemies it found. Loops until its done with all the drones.
        {
            Follower followerScript = capsule.AddComponent<Follower>();
            Attach(followerScript);
        }
    }

    /*
    public void removeFollowers()
    {
        Debug.Log("CHANGE SUBJECT!!!!");
        disableAction();
    }
    */

    public void addFollowers()
    {
        //addFollowers();
    }


    

    private void OnDisable()
    {
        disableAction();
    }

    private void disableAction()
    {
        foreach (GameObject capsule in followerCapsulesArray)
        {
            Follower followerScript = capsule.GetComponent<Follower>();
            Detach(followerScript);
        }
    }
}
