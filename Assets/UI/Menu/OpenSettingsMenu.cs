using UnityEngine;
using UnityEngine.UI;

public class OpenSettingsMenu : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject settingsUI;

    public void OpenSettings()
    {
        menuUI.SetActive(false);
        settingsUI.SetActive(true);
    }
}