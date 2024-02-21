using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
public class ItemManager : Singleton<ItemManager>
{
  
    public int coins;


    private void Start()
    {
        Reset();
    }
    public void AddCoins(int amount = 1)
    {
        coins += amount;
    }

    private void Reset()
    {
        coins = 0;
    }
}
