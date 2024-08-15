using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;

    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }

    [SerializeField] int targetBalance;
    [SerializeField] int changingAmount = 5;


    [SerializeField] GameObject gameOverUI;
    [SerializeField] TextMeshProUGUI goldText;

    private void Awake()
    {
        currentBalance = startingBalance;
        targetBalance = currentBalance;


    }

    void Update()
    {
        StartCoroutine(ChangingCurrentBalance(1f));

    }

    IEnumerator ChangingCurrentBalance(float delayValue)
    {
        if (currentBalance < targetBalance)
        {
            currentBalance += changingAmount;
            goldText.text ="Gold: " + currentBalance.ToString();
            yield return new WaitForSecondsRealtime(1f);

        }
        else if (currentBalance > targetBalance)
        {
            currentBalance -= changingAmount;
            goldText.text = "Gold: " + currentBalance.ToString();
            yield return new WaitForSecondsRealtime(1f);
        }

    }

    public void Deposit(int amount)
    {
        Debug.Log("Depositing money: " + amount);
        targetBalance += Mathf.Abs(amount);
    }

    public void Withdrawal(int amount)
    {
        if (targetBalance > Mathf.Epsilon)
        {
            targetBalance -= Mathf.Abs(amount);
            Mathf.Clamp(targetBalance, 0, Mathf.Infinity);
        }
        else
        {
            // pause the game
            Time.timeScale = 0f;

            // activate game over UI
            gameOverUI.SetActive(true);

        }
    }


}
