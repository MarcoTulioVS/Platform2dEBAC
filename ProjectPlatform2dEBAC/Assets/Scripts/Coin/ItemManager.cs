using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;


    public int coins;


    private void Start()
    {
        Reset();
    }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
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
