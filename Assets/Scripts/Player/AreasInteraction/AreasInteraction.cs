using System;
using UnityEngine;
using UnityEngine.Events;

public class AreasInteraction : MonoBehaviour
{
    public event OnCollisionEnter TreeInTheArea;
    public event OnCollisionEnter RockInTheArea;
    public event OnCollisionEnter FoodInTheArea;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            Debug.Log("TreeInTheArea");
            TreeInTheArea?.Invoke(other.gameObject.GetComponent<Tree>());
        }
        
        if (other.CompareTag("Rock"))
        {
            Debug.Log("RockInTheArea");
            RockInTheArea?.Invoke(other.gameObject.GetComponent<Rock>());
        }
        if (other.CompareTag("Food"))
        {
            Debug.Log("FoodInTheArea");
            FoodInTheArea?.Invoke(other.gameObject.GetComponent<Food>());
        }
    }

    public delegate void OnCollisionEnter(object arg);
}
