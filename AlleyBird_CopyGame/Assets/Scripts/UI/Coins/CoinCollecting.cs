using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollecting : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI totalCoinsText;
    [SerializeField]
    TextMeshProUGUI currentCoinsText;

    private int currentCoins = 0;
    public int CurrentCoins
    {
        get { return currentCoins; }
        set
        {
            currentCoins = value;
            currentCoinsText.text = string.Format(currentCoinsFormat, value);
        }
    }

    const string totalCoinsFormat = "Total {0}";
    const string currentCoinsFormat = "{0}";

    private void Start()
    {
        InitFields();
    }

    public void InitFields()
    {
        CurrentCoins = 0;
        totalCoinsText.text = string.Format(totalCoinsFormat, PlayerPrefs.GetInt("TotalCoins").ToString());
    }

    public void CollectOneCoin()
    {
        CurrentCoins += 1;
    }

    public void RewriteTotalCoins()
    {
        PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") + currentCoins);
    }
}
