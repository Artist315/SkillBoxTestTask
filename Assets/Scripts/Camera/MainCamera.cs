using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform Target;
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        if (Target == null)
        {
            Debug.LogWarning("Camera don't have target");
        }
        else
        {
            position = Target.position - transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Target.position - position;
    }
}
