using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuUI;

    private bool isMenuActive;

    private void Start()
    {
        menuUI.SetActive(false); // ������� ��������� ���� ������
    }

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
        Time.timeScale = 0f; // ������������ ������� �����
    }

    public void DeactivateExitMenu()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1f; // ������������ ������� �����
    }
}
