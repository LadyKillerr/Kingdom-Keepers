using TMPro;
using UnityEngine;

public class InstructionsUI : MonoBehaviour
{
    [SerializeField] GameObject instructionsUI;

    [SerializeField] TextMeshProUGUI ballistaCost;
    [SerializeField] TextMeshProUGUI goldRewardText;
    [SerializeField] TextMeshProUGUI goldPenaltyText;

    EnemyDataManager enemyDataManager;

    SessionManager sessionManager;

    void Awake()
    {
        enemyDataManager = FindAnyObjectByType<EnemyDataManager>();
        sessionManager = FindAnyObjectByType<SessionManager>();
    }

    private void Start()
    {
        UpdateDisplay();
    }

    public void CloseIntructionsUI()
    {
        instructionsUI.SetActive(false);
        Time.timeScale = 1;
        sessionManager.SetIsPaused(false);
    }

    public void OpenInstructionsUI()
    {
        instructionsUI.SetActive(true);
        Time.timeScale = 0;
        sessionManager.SetIsPaused(true);


    }

    void UpdateDisplay()
    {
        goldRewardText.text = "Gold Reward Per Enemy: " + enemyDataManager.BallistaGoldReward;

        goldPenaltyText.text = "Gold Penalty Per Enemy: " + enemyDataManager.BallistaGoldPenalty;
    }

}
