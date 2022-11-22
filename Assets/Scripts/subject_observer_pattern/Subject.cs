using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    private readonly
        ArrayList _observers = new ArrayList();

    protected void Attach(Observer observer)
    {
        _observers.Add(observer); //"Player" class will add a certain Drone to that list of observers (group of other drones).
    }

    protected void Detach(Observer observer)
    {
        _observers.Remove(observer);
    }

    protected void NotifyObservers()
    {
        foreach (Observer observer in _observers)
        {
            observer.Notify(this);
        }
    }

    protected void NotifyObservers(Vector3 tVec)
    {
        foreach (Observer observer in _observers)
        {
            observer.Notify(tVec);
            //The drone only needs to know about the Vector3.
        }
    }
}