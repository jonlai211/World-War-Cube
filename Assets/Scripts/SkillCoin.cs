using UnityEngine;

public class SkillCoin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hero"))
        {
            SkillCoinSpawner spawner = FindObjectOfType<SkillCoinSpawner>();
            if (spawner != null)
            {
                spawner.CoinConsumed(); // Notify spawner that the coin has been consumed
            }
            Destroy(gameObject); // Destroy the skill coin
        }
    }
}