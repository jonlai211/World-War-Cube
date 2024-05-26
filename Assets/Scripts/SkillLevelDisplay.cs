using UnityEngine;
using TMPro;

public class SkillLevelDisplay : MonoBehaviour
{
    public TMP_Text skillLevelText;
    private SkillsManager skillsManager;

    void Start()
    {
        skillsManager = FindObjectOfType<SkillsManager>();
        if (skillsManager == null)
        {
            Debug.LogError("SkillsManager not found!");
            return;
        }

        if (skillLevelText == null)
        {
            Debug.LogError("SkillLevelText is not assigned!");
            return;
        }

        UpdateSkillLevelText();
    }

    void Update()
    {
        UpdateSkillLevelText();
    }

    void UpdateSkillLevelText()
    {
        if (skillsManager != null && skillLevelText != null)
        {
            skillLevelText.text = "Current Skill: " + skillsManager.GetCurrentSkillMethod();
        }
    }
}