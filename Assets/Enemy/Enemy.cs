using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 10;
    [SerializeField] int goldPenalty = 20;

    Bank bank;


    void Awake()
    {
        bank = FindAnyObjectByType<Bank>();
    }

    public void IncreaseGold()
    {
        if (bank == null)
        {
            return;
        }
        else
        {
            bank.Deposit(goldReward);
        }
    }

    public void DecreaseGold()
    {
        if (bank == null)
        {
            return;
        }
        else
        {
            bank.Withdrawal(goldPenalty);
        }

    }
}
