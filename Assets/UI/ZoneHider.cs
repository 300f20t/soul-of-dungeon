using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ZoneHider : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject[] objectsToShow; // Массив объектов для отображения

    // Вызывается, когда мышь входит в зону
    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (GameObject obj in objectsToShow)
        {
            obj.SetActive(true); // Отображаем объекты
        }
    }

    // Вызывается, когда мышь выходит из зоны
    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (GameObject obj in objectsToShow)
        {
            obj.SetActive(false); // Скрываем объекты
        }
    }
}
