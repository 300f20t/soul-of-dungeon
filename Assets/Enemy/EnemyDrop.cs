using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    [SerializeField] private GameObject[] itemsToDrop;
    [SerializeField] private float dropChance = 0.5f;

    private bool hasDroppedItem = false;

    private void OnDestroy()
    {
        if (!hasDroppedItem && ShouldDropItem())
        {
            DropItem();
        }
    }

    private bool ShouldDropItem()
    {
        return UnityEngine.Random.value <= dropChance;
    }

    private void DropItem()
    {
        if (itemsToDrop.Length == 0)
        {
            return;
        }

        int randomIndex = UnityEngine.Random.Range(0, itemsToDrop.Length);
        GameObject itemToDropPrefab = itemsToDrop[randomIndex];

        if (itemToDropPrefab != null)
        {
            Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y);
            GameObject spawnedItem = Instantiate(itemToDropPrefab, spawnPosition, Quaternion.identity);
            spawnedItem.SetActive(true); // Устанавливаем активность заспавненного объекта
            hasDroppedItem = true;
        }
    }
}
