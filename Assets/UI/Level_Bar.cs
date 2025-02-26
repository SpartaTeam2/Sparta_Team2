using UnityEngine;
using UnityEngine.UI;

public class Level_Bar : MonoBehaviour
{
    public PlayerCtrl player;
    public Slider experienceSlider; // ����ġ �����̴�
    public Text levelText; // ���� �ؽ�Ʈ (���� ����)
    public float currentExperience = 0f; // ���� ����ġ
    public float maxExperience = 100f; // �ִ� ����ġ (������ ����)
    public int currentLevel = 1; // ���� ����
    public float experiencePerSecond = 0f; // �ʴ� �����ϴ� ����ġ ��

    void Start()
    {
        experienceSlider.minValue = 0f;
        experienceSlider.maxValue = player.MaxExp;
        experienceSlider.value = player.Exp;

        UpdateLevelText();
    }

    void Update()
    {

        AddExperience(player.Exp);
        UpdateLevelText();
    }


    public void AddExperience(float amount)
    {


        experienceSlider.value = player.Exp;

    }


    


    void UpdateLevelText()
    {
        if (levelText != null)
        {
            levelText.text = "Level: " + player.level;
        }
    }
}


