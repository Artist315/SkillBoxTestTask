using System;
using UnityEngine;
using UnityEngine.Events;

public class AreasInteraction : MonoBehaviour
{
    public event OnCollisionEnter TreeInTheArea;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            Debug.Log("TreeInTheArea");
            TreeInTheArea?.Invoke(other.gameObject);
        }
    }

    public delegate void OnCollisionEnter(object arg);
}
