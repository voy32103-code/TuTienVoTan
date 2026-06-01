using UnityEngine;
using System.Collections.Generic;

public class TechniqueManager : MonoBehaviour
{
    public List<CultivationTechnique> learnedTechniques = new List<CultivationTechnique>();

    void Start()
    {
        LearnStartingTechnique();
        PrintTechniques();
    }

    void LearnStartingTechnique()
    {
        CultivationTechnique qiTechnique = new CultivationTechnique(
            "Dẫn Khí Quyết",
            "Công pháp cơ bản giúp hấp thu linh khí.",
            1,
            10,
            "Luyện Khí",
            "Phàm Phẩm"
        );
        CultivationTechnique swordTechnique = new CultivationTechnique(
        "Ngự Kiếm Thuật",
        "Triệu hồi phi kiếm tự động công kích yêu thú.",
        1,
        10,
        "Luyện Khí",
        "Hoàng Phẩm"
         );
        CultivationTechnique thunderTechnique = new CultivationTechnique(
    "Dẫn Lôi Thuật",
    "Dẫn thiên lôi công kích yêu thú gần nhất.",
    1,
    10,
    "Luyện Khí",
    "Huyền Phẩm"
);

       
        learnedTechniques.Add(qiTechnique);
        learnedTechniques.Add(swordTechnique);
        learnedTechniques.Add(thunderTechnique);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            UpgradeTechnique("Dẫn Khí Quyết");
        }
    }

    public void UpgradeTechnique(string techniqueName)
    {
        CultivationTechnique technique = learnedTechniques.Find(t => t.techniqueName == techniqueName);

        if (technique == null)
        {
            Debug.Log("Chưa học công pháp: " + techniqueName);
            return;
        }

        if (technique.IsMaxLevel())
        {
            Debug.Log(technique.techniqueName + " đã viên mãn.");
            return;
        }

        technique.LevelUp();

        Debug.Log("Nâng cấp công pháp: " + technique.GetDisplayName());
    }

    public void PrintTechniques()
    {
        foreach (CultivationTechnique technique in learnedTechniques)
        {
            Debug.Log(
                technique.GetDisplayName()
                + " | "
                + technique.rarity
                + " | "
                + technique.description
            );
        }
    }
    public int CalculateSpiritExp(int baseExp)
    {
        CultivationTechnique qiTechnique =
            learnedTechniques.Find(t => t.techniqueName == "Dẫn Khí Quyết");

        if (qiTechnique == null)
        {
            return baseExp;
        }

        float bonusMultiplier = 1f + ((qiTechnique.level - 1) * 0.1f);

        return Mathf.RoundToInt(baseExp * bonusMultiplier);
    }
    public int GetTechniqueLevel(string techniqueName)
    {
        CultivationTechnique technique =
            learnedTechniques.Find(t => t.techniqueName == techniqueName);

        if (technique == null)
        {
            return 0;
        }

        return technique.level;
    }
}