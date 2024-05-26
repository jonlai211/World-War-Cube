using UnityEngine;
using TMPro;
using System.Collections;

public class HealthDisplay : MonoBehaviour
{
    public Health targetHealth;
    private TextMeshProUGUI healthText;

    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(InitialHealthUpdate());
    }

    IEnumerator InitialHealthUpdate()
    {
        yield return new WaitForEndOfFrame();
        if (targetHealth != null)
        {
            targetHealth.onDamageTaken.AddListener(UpdateHealthDisplay);
            UpdateHealthDisplay();
        }
    }

    void UpdateHealthDisplay()
    {
        if (healthText != null && targetHealth != null)
        {
            string targetName = targetHealth.gameObject.name;
            healthText.text = targetName + " HP: " + targetHealth.currentHealth + "/" + targetHealth.maxHealth;
        }
    }
}