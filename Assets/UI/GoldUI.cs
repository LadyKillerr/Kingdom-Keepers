using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour
{
    TextMeshProUGUI goldText;
    Bank bank;

    

    void Awake()
    {
        goldText = GetComponent<TextMeshProUGUI>();
        bank = FindAnyObjectByType<Bank>();
    }


    void Update()
    {
        goldText.text = "Gold: " + bank.CurrentBalance.ToString();
    }
}
