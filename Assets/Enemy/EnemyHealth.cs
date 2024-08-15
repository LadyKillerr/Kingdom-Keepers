using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    [SerializeField] int currentHealth;
    [SerializeField] int damageOnHit = 1;

    bool isDead = false;

    Enemy enemy;
    EnemyDataManager enemyDataManager;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        enemyDataManager = FindAnyObjectByType<EnemyDataManager>();
    }

    private void OnEnable()
    {
        currentHealth = maxHealth;
        isDead = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        if (currentHealth > damageOnHit)
        {
            currentHealth -= damageOnHit;

        }
        else
        {
            if (!isDead)
            {
                enemy.IncreaseGold(enemyDataManager.BallistaGoldReward);
                gameObject.SetActive(false);
                isDead = true;
            }
        }
    }
}
