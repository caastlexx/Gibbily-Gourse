using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public GameObject[] singleLaneOpps; // Single-lane obstacles
    public GameObject[] twoLaneOpps; // Two-lane obstacles
    public float spawnZ = 170; // Spawn position on the Z-axis
    private float startDelay = 0f;
    private float laneWidth = 7f; // Distance between lanes
    private int totalLanes = 3; // Number of lanes


    void Start()
    {
        StartCoroutine(SpawnOppsCoroutine());
    }


    IEnumerator SpawnOppsCoroutine()
    {
        // Initial delay
        yield return new WaitForSeconds(startDelay);


        while (true)
        {
            // Spawn obstacles while keeping at least one lane clear
            SpawnOpps();


            // Wait for a random interval between 1 and 3 seconds
            float randomInterval = Random.Range(1f, 1f);
            yield return new WaitForSeconds(randomInterval);
        }
    }


    void SpawnOpps()
    {
        // Randomly decide whether to spawn a two-lane obstacle (30% chance)
        bool spawnTwoLane = Random.value < 0f;


        if (spawnTwoLane)
        {
            SpawnTwoLaneObstacle();
        }
        else
        {
            SpawnSingleLaneObstacles();
        }
    }


    void SpawnSingleLaneObstacles()
    {
        // Randomly determine how many lanes will have obstacles (1 or 2)
        int lanesWithObstacles = Random.Range(3, 3);


        // Generate a list of lane indices (0, 1, 2 for left, center, right)
        List<int> laneIndices = new List<int> { 0, 1, 2 };


        // Shuffle the lane indices
        for (int i = laneIndices.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            int temp = laneIndices[i];
            laneIndices[i] = laneIndices[randomIndex];
            laneIndices[randomIndex] = temp;
        }


        // Select lanes to spawn obstacles
        for (int i = 0; i < lanesWithObstacles; i++)
        {
            int lane = laneIndices[i]; // Get lane index
            Vector3 spawnPos = new Vector3((lane - 1) * laneWidth, 2, spawnZ); // Calculate position


            // Use weighted probability for obstacle selection
            int oppIndex = GetWeightedIndex(new float[] { 1f}); // 70% obstacle 1, 30% obstacle 2


            Instantiate(singleLaneOpps[oppIndex], spawnPos, singleLaneOpps[oppIndex].transform.rotation);
        }
    }


    void SpawnTwoLaneObstacle()
    {
        // Determine which two adjacent lanes to block (left+center or center+right)
        int startLane = Random.Range(0, 2); // 0 = left+center, 1 = center+right


        // Calculate the spawn position (middle of the two lanes)
        float middleLaneX = (startLane - 0.5f) * laneWidth;


        // Randomly select a two-lane obstacle
        int oppIndex = Random.Range(0, twoLaneOpps.Length);


        Vector3 spawnPos = new Vector3(middleLaneX, 2, spawnZ);
        Instantiate(twoLaneOpps[oppIndex], spawnPos, twoLaneOpps[oppIndex].transform.rotation);
    }


    int GetWeightedIndex(float[] weights)
    {
        float totalWeight = 0;
        foreach (float weight in weights)
        {
            totalWeight += weight;
        }


        float randomValue = Random.value * totalWeight;
        float cumulativeWeight = 0;


        for (int i = 0; i < weights.Length; i++)
        {
            cumulativeWeight += weights[i];
            if (randomValue <= cumulativeWeight)
            {
                return i;
            }
        }


        return 0; // Default to the first index (shouldn't happen if weights are valid)
    }
}
