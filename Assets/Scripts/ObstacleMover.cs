using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    [SerializeField] private float speed = 2f; // �������� ��������

    private void Update()
    {
        // ������� ������ �����
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
