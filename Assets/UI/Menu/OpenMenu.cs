using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public GameObject menuUI;

    private bool isMenuActive;

    void Update()
    {
        isMenuActive = menuUI.activeSelf;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isMenuActive)
            {
                ActivateExitMenu();
            }
            else
            {
                DeactivateExitMenu();
            }
        }
    }

    void ActivateExitMenu()
    {
        menuUI.SetActive(true);
        Time.timeScale = 0f; // Замораживаем игровое время
    }

    public void DeactivateExitMenu()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1f; // Возобновляем игровое время
    }
}
