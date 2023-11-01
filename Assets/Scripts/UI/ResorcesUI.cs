using TMPro;
using UnityEngine;

public class ResorcesUI : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI WoodAmount;
    [SerializeField]
    public TextMeshProUGUI FoodAmount;
    [SerializeField]
    public TextMeshProUGUI StoneAmount;

    private void Awake()
    {
        UpdateUI();
        ResourcesStorage.ResourcesUpdated += UpdateUI;        
    }

    private void UpdateUI()
    {
        WoodAmount.text     = $"{ResourcesStorage.Data.Wood}";
        FoodAmount.text     = $"{ResourcesStorage.Data.Food}";
        StoneAmount.text    = $"{ResourcesStorage.Data.Stone}";
    }

    private void OnDestroy()
    {
        ResourcesStorage.ResourcesUpdated -= UpdateUI;
    }
}