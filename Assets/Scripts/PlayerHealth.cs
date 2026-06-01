using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("HP: " + currentHealth + "/" + maxHealth);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player bị đánh! HP: " + currentHealth + "/" + maxHealth);

        if ( currentHealth <= 0)
        {
            Die();
        }

    }
    void Die() 
    {
        PlayerCultivation playerCultivation = GetComponent<PlayerCultivation>();

        GameManager.Instance.GameOver(playerCultivation);
    }
}
