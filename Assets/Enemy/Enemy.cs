using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Bank bank;

    void Awake()
    {
        bank = FindAnyObjectByType<Bank>();
    }
    
    public void IncreaseGold(int increaseValue)
    {
        if (bank == null)
        {
            return;
        }
        else
        {
            bank.Deposit(increaseValue);
        }
    }

    public void DecreaseGold(int decreaseValue)
    {
        if (bank == null)
        {
            return;
        }
        else
        {
            bank.Withdrawal(decreaseValue);
        }

    }
}
