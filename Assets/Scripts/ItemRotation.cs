using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    public int rotationSpeed = 100;
    Transform itemTransform;
    // Start is called before the first frame update
    void Start()
    {
        itemTransform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        itemTransform.Rotate(rotationSpeed * Time.deltaTime, 0, 0); //The standard way pf normalizing movement effects in Unity, so the rotation can appear smooth.
    }
}
