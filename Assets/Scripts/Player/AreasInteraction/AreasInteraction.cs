using System;
using UnityEngine;
using UnityEngine.Events;

public class AreasInteraction : MonoBehaviour
{
    public event OnCollisionEnter TreeInTheArea;
    public event OnCollisionEnter RockInTheArea;
    public event OnCollisionEnter FoodInTheArea;
    public event OnCollisionEnter UpgradeTheArea;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Tree>(out var tree))
        {
            Debug.Log("TreeInTheArea");
            TreeInTheArea?.Invoke(tree);
        }
        
        if (other.TryGetComponent<Rock>(out var rock))
        {
            Debug.Log("RockInTheArea");
            RockInTheArea?.Invoke(rock);
        }
        if (other.TryGetComponent<Food>(out var food))
        {
            Debug.Log("FoodInTheArea");
            FoodInTheArea?.Invoke(food);
        }
        if (other.TryGetComponent<IUpgradeSource>(out var upgradeSource))
        {
            Debug.Log("UpgradeSourceInTheArea");
            UpgradeTheArea?.Invoke(upgradeSource);
        }
    }

    public delegate void OnCollisionEnter(object arg);
}
