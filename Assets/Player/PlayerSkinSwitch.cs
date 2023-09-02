using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinSwitch : MonoBehaviour
{
    [SerializeField] private Sprite[] playerSprites; // ������ �������� ������
    private int currentSkinIndex = 0; // ������ �������� ������� ������
    private SpriteRenderer spriteRenderer; // ��������� ��� ����������� �������

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = playerSprites[currentSkinIndex]; // ��������� ���������� �������
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ������������ �� ��������� ������
            currentSkinIndex++;
            if (currentSkinIndex >= playerSprites.Length)
            {
                currentSkinIndex = 0;
            }

            spriteRenderer.sprite = playerSprites[currentSkinIndex]; // ��������� ������ �������
        }
    }
}
