using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ItemBehavior : MonoBehaviour
{
    public globalStats_player playerStats;
    public Transform PatrolRoute;
    public List<Transform> Locations;
    private int _locationIndex = 0;
    private NavMeshAgent _agent;

    /// <summary>
    /// This is to give the star an AI so it can move similarly to the Enemies. Give the star a "patrol" route, and it will follow that route.
    /// I'm gonna give the star different speeds when the player sees them, so some will move slow, some will move fast. It is a bonus
    /// item, after all ;)
    /// </summary>
 
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }

    void InitializePatrolRoute()
    {
        foreach (Transform child in PatrolRoute)
        {
            Locations.Add(child);
        }
    }

    private void Update()
    {
        if (_agent.remainingDistance < 0.2f && !_agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }

    void MoveToNextPatrolLocation()
    {
        if (Locations.Count == 0)
            return;
        _agent.destination = Locations[_locationIndex].position;
        _locationIndex = (_locationIndex + 1) % Locations.Count;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            //TODO: Implement this as an EVENT, and this code below can be moved to the globalStats_player script,
            //while this script CALLS the event (and then destroys the star item).
            //Extra: depending on the gameMode state, maybe I can increase the Score multiplier.

            playerStats.Points = playerStats.Points * 5;
            if (playerStats.HP < 100)
            {
                playerStats.HP++;
            }
            Destroy(this.transform.gameObject);
            Debug.Log("Booster Item collected!");
        }
    }
}
