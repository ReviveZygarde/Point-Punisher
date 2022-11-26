using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform PatrolRoute;
    public List<Transform> Locations;
    private int _locationIndex = 0;
    private NavMeshAgent _agent;
    //public GameBehavior gameManager;
    private globalStats_player playerStats;
    private globalStats_mode mode;
    public bool bossEntity;
    public int enemyHP = 1; //The variable name was a bit misleading. Changed it from "_lives" -> "enemyHP". I also made it public so i can make bosses
    //public GameObject nextEnemy;
    //private leaderSubjectScript something;

void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
        retreievePlayerStatSingleton();
        //gameManager = GameObject.Find("Game_Manager").GetComponent<GameBehavior>();
        //--------------------
        //something = GetComponent<leaderSubjectScript>();
    }

    private void retreievePlayerStatSingleton() //Since enemies and items will communicate with the Singleton, they derp out and dont change values in the singleton if
                                                //they obviously can't find it. So, instead of me making the enemies/items define what the singleton is in my inspector
                                                //They'll just find out what the singleton is by looking for the game object called "common".
    {
        GameObject common = GameObject.Find("common");
        GameObject gameMode = GameObject.Find("!!!GAME_MODE_SELECTION");
        playerStats = common.GetComponent<globalStats_player>();
        mode = gameMode.GetComponent<globalStats_mode>();
    }


    public int EnemyLives
    {
        get { return enemyHP; }
        private set
        {
            enemyHP = value;
            if (enemyHP <= 0)
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
        if(bossEntity == true)
        {
            playerStats.toStageClearScreen();
        }
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
        if(_locationIndex == Locations.Count)
        {
            this.transform.position = Locations[0].position;
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
        if(collision.gameObject.name == "leftInvisibleWall" || collision.gameObject.name == "rightInvisibleWall" || collision.gameObject.name == "wallPusher")
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), this.GetComponent<Collider>());
            //Since im using a rigidbody to prevent capsules from fusing together, this code tells the enemies to
            //ignore the left and right invisible walls, and wallPusher
        }
    }

}
