using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Follower : Observer
{
    private EnemyBehavior Leader; //caches a reference to the LEADER CAPSULE as soon as its notified.
    private GameObject leaderEnemyObjectInScene;

    public override void Notify(Subject subject)
    {
        if (Leader == null)
        {
            Leader = subject.GetComponent<EnemyBehavior>();
            leaderEnemyObjectInScene = Leader.gameObject;
        }
        // Test again because the return of GetComponent could return null.
        if (Leader != null)
        {
            //Follow the leader
            FollowLeaderStart();
        }
    }

    public override void Notify(Vector3 leaderVec)
    {
        //Follow the leader.
        FollowLeaderStart();
    }

    private void FollowLeaderStart()
    {
        StartCoroutine(Movement());
    }

    IEnumerator Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, leaderEnemyObjectInScene.transform.position, 3f* Time.deltaTime);
        yield return new WaitForSeconds(0.2f); //This determines the gap between the LEADER capsule and FOLLOWER Capsule.
        if (leaderEnemyObjectInScene.IsDestroyed())
        {
            Destroy(this.gameObject);
        }
    }

}
