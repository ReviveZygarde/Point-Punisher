using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletBehavior : MonoBehaviour
{
    public float OnscreenDelay = 0.5f;
    public ObjectPoolScript poolManager;

    public IObjectPool<BulletBehavior> Pool { get; internal set; }

    public void returnToPool()
    {
        Pool.Release(this);
    }

}
