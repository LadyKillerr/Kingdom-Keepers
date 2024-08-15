using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    bool isDead = false;
    
    [SerializeField] int maxHealth = 5;
    [SerializeField] int currentHealth;
    [SerializeField] int damageOnHit = 1;

    [Tooltip("The amount of health enemy increase after every lives")]
    [SerializeField] int difficultyRamp = 1;

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
                maxHealth += difficultyRamp;

                enemy.IncreaseGold(enemyDataManager.BallistaGoldReward);
                gameObject.SetActive(false);
                isDead = true;
            }
        }
    }
}
