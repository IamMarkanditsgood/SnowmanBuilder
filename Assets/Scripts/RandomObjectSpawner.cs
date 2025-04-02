using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPrefabs; // ������ ��������� ��������
    [SerializeField] private Transform spawnPoint; // ����� ������ (X,Z �������������)
    [SerializeField] private float minY = -3f; // ����������� Y ����������
    [SerializeField] private float maxY = 3f; // ������������ Y ����������
    [SerializeField] private float minSpawnDelay = 1f; // ����������� �������� ������
    [SerializeField] private float maxSpawnDelay = 3f; // ������������ �������� ������

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float randomDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(randomDelay);

            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        if (spawnPrefabs.Length == 0) return;

        // �������� ��������� ������
        GameObject randomPrefab = spawnPrefabs[Random.Range(0, spawnPrefabs.Length)];

        // ���������� ��������� ������� �� Y
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(spawnPoint.position.x, randomY, spawnPoint.position.z);

        // ������ ������
        Instantiate(randomPrefab, spawnPosition, Quaternion.identity);
    }
}
