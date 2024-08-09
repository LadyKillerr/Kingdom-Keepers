using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;

    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }

    [SerializeField] GameObject gameOverUI;

    private void Awake()
    {
        
        currentBalance = startingBalance;
    }

    public void Deposit(int amount)
    {
        Debug.Log("Depositing money: " + amount);
        currentBalance += Mathf.Abs(amount);
    }

    public void Withdrawal(int amount)
    {
        if (currentBalance > Mathf.Epsilon)
        {
            Debug.Log("Withdraw money: " + amount);
            currentBalance -= Mathf.Abs(amount);
            Mathf.Clamp(currentBalance, 0, Mathf.Infinity);
        }
        else
        {
            Debug.Log("You have lose the game...");

            // pause the game
            Time.timeScale = 0f;

            // activate game over UI
            gameOverUI.SetActive(true);

        }
    }

    
}
