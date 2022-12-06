using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using static UnityEngine.EventSystems.EventTrigger;

public class ObjectPoolScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int maxPoolSize = 50;
    public int stackDefaultCapacity = 50;
    public GameObject player;
    public playerBehavior playerB;

    public IObjectPool<BulletBehavior> Pool
    {
        get
        {
            if (_pool == null)
                _pool =
                    new ObjectPool<BulletBehavior>(
                        CreatedPooledItem,
                        OnTakeFromPool,
                        OnReturnedToPool,
                        OnDestroyPoolObject,
                        true,
                        stackDefaultCapacity,
                        maxPoolSize);
            return _pool;
        }
    }

    private IObjectPool<BulletBehavior> _pool;

    private BulletBehavior CreatedPooledItem()
    {
        var go = GameObject.Instantiate(bulletPrefab);
        BulletBehavior entity = go.GetComponent<BulletBehavior>();
        if (entity != null)
        {
            go.name = "Bullet";
            entity.Pool = Pool;
            return entity;
        }
        else
        {
            return null;
        }
    }


    private void OnReturnedToPool(BulletBehavior entity)
    {
        entity.gameObject.SetActive(false);
    }

    private void OnTakeFromPool(BulletBehavior entity)
    {
        entity.gameObject.SetActive(true);
    }

    private void OnDestroyPoolObject(BulletBehavior entity)
    {
        //Destroy(EnemyBehavior.gameObject);
    }

    public void spawn()
    {
        var entity = Pool.Get();
        changePositionBackToPlayer(entity);
        Rigidbody BulletRB = entity.GetComponent<Rigidbody>();
        BulletRB.velocity = player.transform.forward * playerB.BulletSpeed;
        StartCoroutine(WaitForReturn(entity));
    }

    IEnumerator WaitForReturn(BulletBehavior entity)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(entity.OnscreenDelay);
        yield return waitForSeconds;
        entity.returnToPool();
        changePositionBackToPlayer(entity);
        yield return null;
    }

    private void changePositionBackToPlayer(BulletBehavior entity)
    {
        entity.transform.position = player.transform.position + new Vector3(0, 0, 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerB = player.GetComponent<playerBehavior>();
    }
    
}
