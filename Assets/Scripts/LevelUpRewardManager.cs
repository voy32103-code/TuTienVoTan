using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpRewardManager : MonoBehaviour
{
    public PlayerCultivation playerCultivation;
    public TechniqueManager techniqueManager;

    public GameObject rewardPanel;

    public Button rewardButton1;
    public Button rewardButton2;
    public Button rewardButton3;

    public TMP_Text rewardButton1Text;
    public TMP_Text rewardButton2Text;
    public TMP_Text rewardButton3Text;

    void Start()
    {
        playerCultivation.OnLevelUp += ShowRewardChoices;

        rewardPanel.SetActive(false);

        rewardButton1.onClick.AddListener(ChooseReward1);
        rewardButton2.onClick.AddListener(ChooseReward2);
        rewardButton3.onClick.AddListener(ChooseReward3);
    }

    void ShowRewardChoices()
    {
        Time.timeScale = 0f;

        rewardPanel.SetActive(true);

        rewardButton1.interactable = true;
        rewardButton2.interactable = true;
        rewardButton3.interactable = true;

        rewardButton1Text.text = "Dẫn Khí Quyết\nTăng hấp thu linh khí";

        CultivationTechnique swordTechnique =
            techniqueManager.learnedTechniques.Find(t => t.techniqueName == "Ngự Kiếm Thuật");

        if (swordTechnique != null && swordTechnique.IsMaxLevel())
        {
            rewardButton2Text.text = "Ngự Kiếm Thuật\nĐã viên mãn";
            rewardButton2.interactable = false;
        }
        else
        {
            rewardButton2Text.text = "Ngự Kiếm Thuật\nTăng sức mạnh phi kiếm";
        }

        rewardButton3Text.text = "Dẫn Lôi Thuật\nTăng sức mạnh thiên lôi";
    }

    void ChooseReward1()
    {
        techniqueManager.UpgradeTechnique("Dẫn Khí Quyết");
        CloseRewardPanel();
    }

    void ChooseReward2()
    {
        CultivationTechnique swordTechnique =
        techniqueManager.learnedTechniques.Find(t => t.techniqueName == "Ngự Kiếm Thuật");

        if (swordTechnique != null && swordTechnique.IsMaxLevel())
        {
            Debug.Log("Ngự Kiếm Thuật đã viên mãn, không thể nâng thêm.");
            return;
        }

        techniqueManager.UpgradeTechnique("Ngự Kiếm Thuật");

        CloseRewardPanel();
    }

    void ChooseReward3()
    {
        techniqueManager.UpgradeTechnique("Dẫn Lôi Thuật");
        CloseRewardPanel();
    }

    void CloseRewardPanel()
    {
        rewardPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}