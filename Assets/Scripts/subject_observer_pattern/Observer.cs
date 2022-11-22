using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Observer : MonoBehaviour
{
    public abstract void Notify(Subject subject);

    public abstract void Notify(Vector3 vec);
}