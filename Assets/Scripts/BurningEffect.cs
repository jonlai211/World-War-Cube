using UnityEngine;

public class BurningEffect : MonoBehaviour
{
    public float duration = 5.0f;
    public int damagePerSecond = 2;
    private float damageTimer = 0;
    private float remainingDuration;
    private Color originalColor;
    private bool isActive = false;

    public void Activate()
    {
        if (!isActive)
        {
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                originalColor = renderer.material.color;
                renderer.material.color = Color.red;
            }
            isActive = true;
            remainingDuration = duration;
            damageTimer = 0;
        }
    }

    void Update()
    {
        if (isActive)
        {
            damageTimer += Time.deltaTime;

            if (damageTimer >= 1.0f)
            {
                Health health = GetComponent<Health>();
                if (health != null)
                {
                    health.TakeDamage(damagePerSecond);
                }
                damageTimer = 0;
            }

            remainingDuration -= Time.deltaTime;
            if (remainingDuration <= 0)
            {
                Renderer renderer = GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = originalColor;
                }
                isActive = false;
                damageTimer = 0;
            }
        }
    }
}