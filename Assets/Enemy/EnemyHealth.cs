using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    [SerializeField] int currentHealth;
    [SerializeField] int damageOnHit = 1;

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
            Debug.Log("Enemy has been deduct health");
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
