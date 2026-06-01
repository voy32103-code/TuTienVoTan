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
    public int requiredExp = 10;

    public void AddExp(int amount) 
    {
        currentExp += amount;
        if ( currentExp >= requiredExp)
        {
            LevelUp();
        }
        Debug.Log(GetCultivationName() + " | Tu vi: " + currentExp + "/" + requiredExp);
    }
    void LevelUp() 
    {
        currentExp -= requiredExp;

        // Nếu đang tầng 1-8 thì tăng tầng bình thường
        if (stage < 9)
        {
            stage++;

            requiredExp += 10;

            Debug.Log("Đột phá thành công! Hiện tại: " + GetCultivationName());

            OnLevelUp?.Invoke();
            return;
        }

        // Nếu đang tầng 9 và chưa viên mãn
        if (stage == 9 && !isPerfectStage)
        {
            isPerfectStage = true;

            requiredExp += 20;

            Debug.Log("Đã đạt " + GetCultivationName() + "! Chuẩn bị tiến giai.");

            OnLevelUp?.Invoke();
            return;
        }

        // Nếu đã viên mãn, đủ tu vi thì bắt đầu tiến giai/quái triều
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

        requiredExp += 30;

        Debug.Log("Tiến giai thành công! Hiện tại: " + GetCultivationName());

        OnLevelUp?.Invoke();
    }


}
