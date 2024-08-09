using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    [SerializeField] int currentHealth;
    [SerializeField] int damageOnHit = 1;

    Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        currentHealth = maxHealth;
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
            gameObject.SetActive(false);
            enemy.IncreaseGold();
        }
    }
}
