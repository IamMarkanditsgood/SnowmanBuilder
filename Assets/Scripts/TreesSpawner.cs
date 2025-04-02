using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab; // ������ �����������
    [SerializeField] private Transform spawnPoint; // ����� ������
    [SerializeField] private float spawnInterval = 2f; // �������� ������� ������
    [SerializeField] private float spawnChance = 50f; // ���� ������ (0-100%)

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // ��������� ����
            if (Random.Range(0f, 100f) <= spawnChance)
            {
                SpawnObstacle();
            }
        }
    }

    private void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity);
    }
}
