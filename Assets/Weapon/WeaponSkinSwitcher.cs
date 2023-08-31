using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSkinSwitcher : MonoBehaviour
{
    public Sprite[] skins;
    public SpriteRenderer spriteRenderer;

    private int currentSkinIndex = 0;

    void Start()
    {
        spriteRenderer.sprite = skins[currentSkinIndex];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentSkinIndex++;
            if (currentSkinIndex >= skins.Length)
            {
                currentSkinIndex = 0;
            }
            spriteRenderer.sprite = skins[currentSkinIndex];
        }
    }
}
