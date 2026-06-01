using UnityEngine;

public class LevelUpRewardManager : MonoBehaviour
{
    public PlayerCultivation playerCultivation;
    public TechniqueManager techniqueManager;
    public PlayerAutoAttack playerAutoAttack;
    public PlayerMovement playerMovement;

    void Start()
    {
        playerCultivation.OnLevelUp += ShowRewardChoices;
    }

    void Update()
    {
        if (Time.timeScale == 0f && Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChooseReward1();
        }

        if (Time.timeScale == 0f && Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChooseReward2();
        }

        if (Time.timeScale == 0f && Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChooseReward3();
        }
    }

    void ShowRewardChoices()
    {
        Time.timeScale = 0f;

        Debug.Log("LEVEL UP REWARD!");
        Debug.Log("1. Nâng Dẫn Khí Quyết");
        Debug.Log("2. Tăng sát thương");
        Debug.Log("3. Tăng tốc chạy");
    }

    void ChooseReward1()
    {
        techniqueManager.UpgradeTechnique("Dẫn Khí Quyết");

        Time.timeScale = 1f;
        Debug.Log("Đã chọn: Nâng Dẫn Khí Quyết");
    }
    void ChooseReward2()
    {
        playerAutoAttack.IncreaseDamage(1);

        Time.timeScale = 1f;
        Debug.Log("Đã chọn: Tăng sát thương");
    }

    void ChooseReward3()
    {
        playerMovement.IncreaseSpeed(0.5f);

        Time.timeScale = 1f;
        Debug.Log("Đã chọn: Tăng tốc chạy");
    }
}