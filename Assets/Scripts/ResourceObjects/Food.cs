using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Food : MonoBehaviour, ResourceObject
{
    public int ResourceProTick { get; set; } = 10;
    public int ResourceAmount { get; set; } = 1000;
}
