using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;
public class ItemManager : Singleton<ItemManager>
{
  
    public SOInt coins;

    private void Start()
    {
        Reset();
    }
    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        UpdateUI();
    }

    private void Reset()
    {
        coins.value = 0;
    }

    private void UpdateUI()
    {
        //uiTextCoins.text = coins.ToString();
        UIInGameManager.instance.UpdateTextCoins(coins.value.ToString());
    }
}
