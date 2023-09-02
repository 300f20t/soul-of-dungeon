using UnityEngine;

public class ExitMenu : MonoBehaviour
{
    [SerializeField] private GameObject exitMenuUI;

    private bool isExitMenuActive;

    private void Start()
    {
        exitMenuUI.SetActive(false); // Сначала отключаем меню выхода
    }

    void Update()
    {
        isExitMenuActive = exitMenuUI.activeSelf;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isExitMenuActive)
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
        exitMenuUI.SetActive(true);
    }

    void DeactivateExitMenu()
    {
        exitMenuUI.SetActive(false);
    }
}
