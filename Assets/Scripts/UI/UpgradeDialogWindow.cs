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
    private ErrowWindow _errorWindow;

    private void Awake()
    {
        _upgradeButton = GetComponentInChildren<Button>();
        _errorWindow = GetComponentInChildren<ErrowWindow>(); 
        _errorWindow.gameObject.SetActive(false);
        if (_upgradeButton == null)
        {
            throw new Exception("No button in children");
        }
        if (_errorWindow == null)
        {
            throw new Exception("No errorWindow in children");
        }
        _text = GetComponentInChildren<TextMeshProUGUI>();
        gameObject.SetActive(false);
    }

    public void OnClick()
    {
        
        if (upgradeSource.Upgrade())
        {
            gameObject.SetActive(false);

        }
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
            OnError("Достигнут максимальный уровень");
            _upgradeButton.gameObject.SetActive(false);

        }
    }

    public void OnError(string text)
    {
        //_text.text = text;
        _errorWindow.SentText(text);
    }

    public void CloseError()
    {
        _errorWindow.gameObject.SetActive(false);
    }


}
