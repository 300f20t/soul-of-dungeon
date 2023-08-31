using UnityEngine;
using TMPro;

public class PlayerCoins : MonoBehaviour
{
    public int coins = 0;
    private TextMeshProUGUI textToEdit;

    void Start()
    {
        textToEdit = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        
        textToEdit.text = coins.ToString();
    }

    public void AddCoins()
    {
        coins++;
    }
}
