using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;
public class ItemManager : Singleton<ItemManager>
{
  
    public int coins;
    public TextMeshProUGUI uiTextCoins;

    private void Start()
    {
        Reset();
    }
    public void AddCoins(int amount = 1)
    {
        coins += amount;
        UpdateUI();
    }

    private void Reset()
    {
        coins = 0;
    }

    private void UpdateUI()
    {
        uiTextCoins.text = coins.ToString();
    }
}
