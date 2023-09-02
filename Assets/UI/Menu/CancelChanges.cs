using UnityEngine;
using UnityEngine.UI;

public class CancelChanges : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject settingsUI;
    
    public void Cancel()
    {
        menuUI.SetActive(true);
        settingsUI.SetActive(false);
    }
}
