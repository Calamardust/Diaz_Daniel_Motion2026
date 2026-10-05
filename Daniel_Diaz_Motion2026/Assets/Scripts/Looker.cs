using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class Looker : MonoBehaviour
{

    public List<Transform> targets; // List of targets to look at

    int i = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            i++;

            if (i >= targets.Count)
            {
                i = 0;
            }
        }
        float angle = TestAngles.VectortoAngle(targets[i].position - transform.position);
        transform.eulerAngles = new Vector3(0, 0, angle);

    }
}
