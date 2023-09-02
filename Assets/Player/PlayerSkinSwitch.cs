using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinSwitch : MonoBehaviour
{
    [SerializeField] private Sprite[] playerSprites; // массив спрайтов игрока
    private int currentSkinIndex = 0; // индекс текущего спрайта игрока
    private SpriteRenderer spriteRenderer; // компонент для отображения спрайта

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = playerSprites[currentSkinIndex]; // установка стартового спрайта
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // переключение на следующий спрайт
            currentSkinIndex++;
            if (currentSkinIndex >= playerSprites.Length)
            {
                currentSkinIndex = 0;
            }

            spriteRenderer.sprite = playerSprites[currentSkinIndex]; // установка нового спрайта
        }
    }
}
