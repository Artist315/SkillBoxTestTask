using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDialogWindow : MonoBehaviour
{
    private Button _upgradeButton;
    private TextMeshProUGUI _text;
    private IUpgradeSource upgradeSource;

    private void Awake()
    {
        _upgradeButton = GetComponentInChildren<Button>();
        if (_upgradeButton == null)
        {
            throw new Exception("No button in children");
        }
        _text = GetComponentInChildren<TextMeshProUGUI>();
        gameObject.SetActive(false);
    }

    public void OnClick()
    {
        upgradeSource.Upgrade();
        gameObject.SetActive(false);
    }

    internal void Activate(IUpgradeSource upgradeSource)
    {
        this.upgradeSource = upgradeSource;
        if (upgradeSource.Level < upgradeSource.MaxLevel)
        {
            gameObject.SetActive(true);

            if (! _upgradeButton.gameObject.activeSelf)
            {
                _upgradeButton.gameObject.SetActive(true);
            }

            _text.text = upgradeSource.UIText;
        }
        else
        {
            _text.text = "Достигнут максимальный уровень";
            _upgradeButton.gameObject.SetActive(false);

        }
    }
}
