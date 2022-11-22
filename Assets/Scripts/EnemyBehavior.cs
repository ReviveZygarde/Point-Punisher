using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform PatrolRoute;
    public List<Transform> Locations;
    private int _locationIndex = 0;
    private NavMeshAgent _agent;
    public Transform Player;
    //public GameBehavior gameManager;
    public globalStats_player playerStats;
    private int _lives = 1;
    //public GameObject nextEnemy;
    //private leaderSubjectScript something;

void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
        Player = GameObject.Find("Player").transform;
        //gameManager = GameObject.Find("Game_Manager").GetComponent<GameBehavior>();
        //--------------------
        //something = GetComponent<leaderSubjectScript>();
    }

    public int EnemyLives
    {
        get { return _lives; }
        private set
        {
            _lives = value;
            if (_lives <= 0)
            {
                playerStats.Points = playerStats.Points + 10;
                //Destroy(this.gameObject);
                FakeDestroy();
                Debug.Log("Enemy down");
            }
        }
    }

    void FakeDestroy() //This destroys certain components of the enemy, but doesn't destroy it entirely.
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        //Destroy(GetComponent<CapsuleCollider>());
        //Destroy(GetComponent<MeshRenderer>());
        //something.removeFollowers();
    }

    void InitializePatrolRoute()
    {
        if(PatrolRoute != null)
        {
            foreach (Transform child in PatrolRoute)
            {
                Locations.Add(child);
            }
        }
    }

    private void Update()
    {
        if (GetComponent<NavMeshAgent>().enabled)
        {
            if (_agent.remainingDistance < 0.2f && !_agent.pathPending)
            {
                MoveToNextPatrolLocation();
            }
        }
    }

    void MoveToNextPatrolLocation()
    {
        if (Locations.Count == 0)
        {
            return;
        }
        _agent.destination = Locations[_locationIndex].position;
        _locationIndex = (_locationIndex + 1) % Locations.Count;
    }

    /*
    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            _agent.destination = Player.position;
            Debug.Log("Player detected. attack!!!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log("Player is out of range.");
        }
    }
    */

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            EnemyLives -= 1;
            Debug.Log("Critical hit");
        }
        if (collision.gameObject.name == "Player")
        {
            playerStats.HP -= 10;
            Debug.Log("Critical hit");
        }
    }

}
