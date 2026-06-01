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
        Debug.Log("2. Nâng Ngự Kiếm Thuật");
        Debug.Log("3. Nâng Dẫn Lôi Thuật");

    }

    void ChooseReward1()
    {
        techniqueManager.UpgradeTechnique("Dẫn Khí Quyết");

        Time.timeScale = 1f;
        Debug.Log("Đã chọn: Nâng Dẫn Khí Quyết");
    }
    void ChooseReward2()
    {
        techniqueManager.UpgradeTechnique("Ngự Kiếm Thuật");

        Time.timeScale = 1f;
        Debug.Log("Đã chọn: Nâng Ngự Kiếm Thuật");
    }

    void ChooseReward3()
    {
        techniqueManager.UpgradeTechnique("Dẫn Lôi Thuật");

        Time.timeScale = 1f;
        Debug.Log("Đã chọn: Nâng Dẫn Lôi Thuật");
    }
}