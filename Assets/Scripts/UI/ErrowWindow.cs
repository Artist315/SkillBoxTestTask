using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ErrowWindow : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI text;
    internal void SentText(string message)
    {
        gameObject.SetActive(true);
        text.text = message;
    }

    public void OnButtonClick()
    {
        gameObject.SetActive(false);
    }
}
