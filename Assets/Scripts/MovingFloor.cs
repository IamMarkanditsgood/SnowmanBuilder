using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour
{
    [SerializeField] private float speed = 2f; // �������� ��������
    [SerializeField] private float resetPositionX = 10f; // ��� ������ �������� ������
    [SerializeField] private float thresholdX = -10f; // ��� ������ �������� � ����������� �����
    [SerializeField] private float minY = -2f; // ����������� Y
    [SerializeField] private float maxY = 2f; // ������������ Y
    [SerializeField] private float heightStep = 1f; // ��� ��������� Y

    private void Update()
    {
        // ������� ������ �����
        transform.position += Vector3.left * speed * Time.deltaTime;

        // ���� ������ ���� �� �������, ��������� ��� ����� � ����� Y
        if (transform.position.x <= thresholdX)
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = resetPositionX;

        // �������� ��������� Y � �������� �����
        int steps = Mathf.FloorToInt((maxY - minY) / heightStep); // ���������� ��������� �����
        float randomStep = Random.Range(0, steps + 1) * heightStep; // �������� ��������� ���
        newPosition.y = minY + randomStep;

        transform.position = newPosition;
    }
}
