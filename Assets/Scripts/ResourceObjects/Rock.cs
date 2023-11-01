
using UnityEngine;

public class Rock : MonoBehaviour, ResourceObject
{
    private int resourceAmount = 60;

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
