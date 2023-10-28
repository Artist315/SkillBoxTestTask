using TMPro;
using UnityEngine;

public class ResorcesUI : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI WoodAmount;

    private void Awake()
    {
        ResourcesStorage.ResourcesUpdated += UpdateUI;
        UpdateUI();
    }

    private void UpdateUI()
    {
        WoodAmount.text = $": {ResourcesStorage.Data.Wood}";
    }

    private void OnDestroy()
    {
        ResourcesStorage.ResourcesUpdated -= UpdateUI;
    }
}