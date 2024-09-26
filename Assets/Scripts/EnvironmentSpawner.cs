using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class EnvironmentSpawner : MonoBehaviour
{
    [Header("Tile Settings")]
    [Range(0, 20)][SerializeField] private int columnLength;
    [Range(0, 20)][SerializeField] private int rowLength;

    [Range(0, 20)][SerializeField] private float xSpace;
    [Range(0, 20)][SerializeField] private float zSpace;

    [SerializeField] private GameObject planePrefab;

    [Header("Player Settings OFF ATM")] 
    [SerializeField] private GameObject playerPrefab;
    private float playerSpawnRange = 50;
    
    [Header("Enemy Settings")]
    [SerializeField] private GameObject enemyPrefab;
    private float enemySpawnRange = 90;
    void Start()
    {
        spawnGenerator();
        PlayerSpawner();
        EnemeySpawner();
    }

    private void spawnGenerator()
    {
        // Calculate total grid dimensions
        float totalWidth = (columnLength - 1) * xSpace;
        float totalHeight = (rowLength - 1) * zSpace;

        // Center offset to start spawning from the center
        Vector3 centerOffset = new Vector3(-totalWidth / 2, 0, -totalHeight / 2);

        // Using the object prefab to generate a grid for the environment
        for (int i = 0; i < columnLength * rowLength; i++)
        {
            // Calculate position with center offset
            Vector3 spawnPosition = new Vector3(
                (xSpace * (i % columnLength)),
                0,
                (zSpace * (i / columnLength))
            ) + centerOffset;

            Instantiate(planePrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }

    
    private void PlayerSpawner()
    {
        float spawnPosX = Random.Range(-playerSpawnRange, playerSpawnRange);
        float spawnPosZ = Random.Range(-playerSpawnRange, playerSpawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 5, spawnPosZ);
        
        Instantiate(playerPrefab, randomPos, playerPrefab.transform.rotation);
       
    }
    
    private Vector3 EnemeySpawner()
    {
        float spawnPosX = Random.Range(-enemySpawnRange, enemySpawnRange);
        float spawnPosZ = Random.Range(-enemySpawnRange, enemySpawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 5, spawnPosZ);
     
        Instantiate(enemyPrefab, randomPos, enemyPrefab.transform.rotation);

        return randomPos;
    }
}