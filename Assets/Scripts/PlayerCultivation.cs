using UnityEngine;

public class PlayerCultivation : MonoBehaviour
{
    public System.Action OnLevelUp;
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
        stage++;
        if (stage > 9 ) 
        {
            stage = 1;
            realmIndex++;
            if (realmIndex >= realms.Length)
            {
                realmIndex = realms.Length - 1; // Max realm reached
               
            }

        }
        requiredExp += 10;
        Debug.Log("Đột phá thành công! Hiện tại: " + GetCultivationName());
        OnLevelUp?.Invoke();
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
        return realms[realmIndex] + " tầng " + stage;
    }


}
