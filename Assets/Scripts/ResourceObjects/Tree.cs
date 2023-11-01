using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Tree : MonoBehaviour, ResourceObject
{
    private int resourceAmount = 40;

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
