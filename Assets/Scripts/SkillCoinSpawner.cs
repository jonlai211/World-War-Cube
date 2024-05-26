using UnityEngine;

public class SkillCoinSpawner : MonoBehaviour
{
    public GameObject skillCoinPrefab;
    public SkillsManager skillsManager;
    private GameObject currentSkillCoin;
    private int coinsSpawned = 0;
    private const int maxCoins = 3;

    void Start()
    {
        SpawnSkillCoin();
    }

    public void SpawnSkillCoin()
    {
        if (currentSkillCoin != null || coinsSpawned >= maxCoins) return;

        Vector3 spawnPosition;
        bool validPosition = false;
        int attempts = 0;

        while (!validPosition && attempts < 100)
        {
            spawnPosition = new Vector3(Random.Range(1, 30), 0.25f, Random.Range(1, 30));
            if (IsPositionValid(spawnPosition))
            {
                currentSkillCoin = Instantiate(skillCoinPrefab, spawnPosition, Quaternion.identity);
                validPosition = true;
                coinsSpawned++;
            }
            attempts++;
        }
    }

    bool IsPositionValid(Vector3 position)
    {
        foreach (var obstaclePos in ObstacleGenerator.obstaclePositions)
        {
            if (Vector3.Distance(position, obstaclePos) < 2) // Adjust distance threshold as needed
                return false;
        }
        return true;
    }
    
    public void CoinConsumed()
    {
        currentSkillCoin = null;
        if (skillsManager != null)
        {
            skillsManager.AddAOESkill(); // Add AOE skill
        }
        else
        {
            Debug.LogWarning("SkillsManager reference not set in SkillCoinSpawner.");
        }

        if (coinsSpawned < maxCoins)
        {
            SpawnSkillCoin();
        }
    }
}