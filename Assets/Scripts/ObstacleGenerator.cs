using UnityEngine;
using System.Collections.Generic;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstaclePrefab; 
    public int totalObstacles = 20;
    public int mapWidth = 31;
    public int mapHeight = 31;
    public int obstaclesWithTwoUnitsHigh = 5;
    
    public static List<Vector3> obstaclePositions; // List to store obstacle positions

    void Start()
    {
        obstaclePositions = new List<Vector3>(); // Initialize the list
        GenerateObstacles();
    }

    void GenerateObstacles()
    {
        for (int i = 0; i < totalObstacles; i++)
        {
            Vector3 position = RandomPosition(i < obstaclesWithTwoUnitsHigh);
            if (position != Vector3.zero) // Ensure position is valid
            {
                obstaclePositions.Add(position); // Store the position
                GameObject newObstacle = Instantiate(obstaclePrefab, position, Quaternion.identity, transform);

                if (i < obstaclesWithTwoUnitsHigh)
                {
                    newObstacle.transform.localScale = new Vector3(1, 2, 1);
                }
            }
        }
    }

    Vector3 RandomPosition(bool isTwoUnitsHigh)
    {
        float x, z;
        float bossMinX = 13, bossMaxX = 17;
        float bossMinZ = 13, bossMaxZ = 17;
        int attempts = 0;

        Vector3 potentialPosition;
        do
        {
            x = Random.Range(1, mapWidth - 1);
            z = Random.Range(1, mapHeight - 1);
            // Adjust Y based on the obstacle's height
            float y = isTwoUnitsHigh ? 1.0f : 0.5f; 
            potentialPosition = new Vector3(x, y, z);

            attempts++;
            if (attempts > 50) // Avoid infinite loops
            {
                return Vector3.zero;
            }
        } while ((x >= bossMinX && x <= bossMaxX && z >= bossMinZ && z <= bossMaxZ) || PositionIsOccupied(potentialPosition));

        return potentialPosition;
    }

    bool PositionIsOccupied(Vector3 position)
    {
        foreach (Vector3 pos in obstaclePositions)
        {
            if (Vector3.Distance(pos, position) < 1) // Assuming a minimal distance to consider a position 'occupied'
                return true;
        }
        return false;
    }
}
