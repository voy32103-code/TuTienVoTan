using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public TMP_Text healthText;

    void Update()
    {
        healthText.text = "HP: "
            + playerHealth.currentHealth
            + " / "
            + playerHealth.maxHealth;
    }
}