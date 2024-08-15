using UnityEngine;

public class EnemyDataManager : MonoBehaviour
{
    EnemyDataManager enemyDataManager;

    [SerializeField] int ballistaGoldReward = 10;
    public int BallistaGoldReward { get { return ballistaGoldReward; } }

    [SerializeField] int ballistaGoldPenalty = 20;
    public int BallistaGoldPenalty { get { return ballistaGoldPenalty; } }

    void Awake()
    {
        enemyDataManager = FindAnyObjectByType<EnemyDataManager>();
    }



}
