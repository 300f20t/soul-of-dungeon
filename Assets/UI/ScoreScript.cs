using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public int score;
    private TextMeshProUGUI textToEdit;

    void Start()
    {
        textToEdit = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textToEdit.text = score.ToString();
    }

    public void AddScore(int value)
    {
        score += value;
    }
}
