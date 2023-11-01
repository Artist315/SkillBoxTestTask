using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Food : MonoBehaviour, ResourceObject
{
    private int resourceAmount = 100;

    public int ResourceAmount 
    {
        get
        {
            return resourceAmount;
        }
        set
        {
            resourceAmount = value;
            if (resourceAmount <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
