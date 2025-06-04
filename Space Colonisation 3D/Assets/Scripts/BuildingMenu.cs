using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildingMenu : MonoBehaviour
{
    RectTransform rectTransform;
    TextMeshProUGUI buildingTypeText;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        buildingTypeText = transform.Find("BuildingType").GetComponent<TextMeshProUGUI>();
    }

    public void closeMenu()
    {
        rectTransform.anchoredPosition = new Vector3(-150, 0, 0);
    }

    public void openMenu(GameObject selectedBuilding)
    {
        rectTransform.anchoredPosition = new Vector3(130, 0, 0);
        buildingTypeText.text = selectedBuilding.name;
    }
}