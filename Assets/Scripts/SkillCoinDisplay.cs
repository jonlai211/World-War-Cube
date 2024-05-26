using TMPro;
using UnityEngine;

public class SkillCoinDisplay : MonoBehaviour
{
    public SkillsManager skillsManager;
    private TextMeshProUGUI skillCoinText;

    void Start()
    {
        skillCoinText = GetComponent<TextMeshProUGUI>();
        UpdateSkillCoinDisplay();
    }

    void Update()
    {
        UpdateSkillCoinDisplay();
    }

    void UpdateSkillCoinDisplay()
    {
        if (skillsManager != null && skillCoinText != null)
        {
            skillCoinText.text = "Skill Coin: " + skillsManager.aoeSkillCount;
        }
    }
}