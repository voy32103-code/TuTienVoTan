using UnityEngine;

public class PlayerCultivation : MonoBehaviour
{
    public System.Action OnBreakthroughRequired;
    public bool isWaitingForBreakthrough = false;
    public System.Action OnLevelUp;
    public bool isPerfectStage = false;
  
    public string[] realms =
    {
       "Luyện Khí",
        "Trúc Cơ",
        "Kim Đan",
        "Nguyên Anh",
        "Hóa Thần",
        "Luyện Hư",
        "Hợp Thể",
        "Độ Kiếp",
        "Đại Thừa",
        "Phi Thăng",
        "Tàn Tiên",
        "Tiên Cảnh"
    };
    public int realmIndex = 0;
    public int stage = 1;

    public int currentExp = 0;
    public int requiredExp = 100;

    public void AddExp(int amount)
    {
        currentExp += amount;

        if (currentExp >= requiredExp && !isWaitingForBreakthrough)
        {
            LevelUp();
        }

        Debug.Log(GetCultivationName() + " | Tu vi: " + currentExp + "/" + requiredExp);
    }
    void LevelUp() 
    {
        currentExp -= requiredExp;

        // Tầng 1 -> tầng 8
        if (stage < 9)
        {
            stage++;

            requiredExp = GetRequiredExpForCurrentStage();

            Debug.Log("Đột phá thành công! Hiện tại: " + GetCultivationName());

            OnLevelUp?.Invoke();
            return;
        }

        // Tầng 9 -> viên mãn
        if (stage == 9 && !isPerfectStage)
        {
            isPerfectStage = true;

            requiredExp = GetRequiredExpForCurrentStage();

            Debug.Log("Đã đạt " + GetCultivationName() + "! Chuẩn bị tiến giai.");

            OnLevelUp?.Invoke();
            return;
        }

        // Viên mãn -> kích hoạt quái triều
        if (isPerfectStage && !isWaitingForBreakthrough)
        {
            isWaitingForBreakthrough = true;

            Debug.Log("Bình cảnh xuất hiện! Cần vượt qua quái triều để tiến giai.");

            OnBreakthroughRequired?.Invoke();
            return;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            AddExp(5);
        }
    }
    public string GetCultivationName()
    {

        if (isPerfectStage)
        {
            return realms[realmIndex] + " viên mãn";
        }

        return realms[realmIndex] + " tầng " + stage;
    }
    public void CompleteBreakthrough()
    {
        if (!isWaitingForBreakthrough)
        {
            return;
        }

        isWaitingForBreakthrough = false;
        isPerfectStage = false;

        stage = 1;
        realmIndex++;

        if (realmIndex >= realms.Length)
        {
            realmIndex = realms.Length - 1;
        }

        requiredExp = GetRequiredExpForCurrentStage();

        Debug.Log("Tiến giai thành công! Hiện tại: " + GetCultivationName());

        OnLevelUp?.Invoke();
    }
    void Start()
    {
        requiredExp = GetRequiredExpForCurrentStage();
    }
    int GetRequiredExpForCurrentStage()
    {
        // Tầng 1 cần 100
        if (stage == 1 && !isPerfectStage)
        {
            return 100;
        }

        // Tầng 2 cần 150
        if (stage == 2 && !isPerfectStage)
        {
            return 150;
        }

        // Tầng 3 trở đi: 175, 200, 225...
        if (!isPerfectStage)
        {
            return 150 + ((stage - 2) * 25);
        }

        // Viên mãn cần thêm 350 để kích hoạt tiến giai
        return 350;
    }


}
