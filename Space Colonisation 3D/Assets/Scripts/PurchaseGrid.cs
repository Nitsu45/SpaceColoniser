using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PurchaseGrid : MonoBehaviour
{
    [SerializeField] GameObject Canvas;
    [SerializeField] GameObject BuyButton;
    [SerializeField] GameObject PurchasePopOut;

    RectTransform rectTransform;

    GameObject instantiatedPopoutWindow;

    Vector3 costOreEnergyManpower = new Vector3(1, 2, 3);
    Vector3 buttonCost;
    Vector3 buttonProduction;

    int generatedButtonAmount = 0;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        
        generateButtons();
    }

    public void mouseHoverOverButton(string buttonName)
    {
        //Creates the popout window that shows the details of the building you're about to purchase.
        GameObject buttonReference = transform.Find(buttonName).gameObject;
        instantiatedPopoutWindow = Instantiate(PurchasePopOut, buttonReference.transform.position + new Vector3(0, 160), Quaternion.identity);
        instantiatedPopoutWindow.transform.SetParent(Canvas.transform);

        //Gets the cost and production values of whichever building you're hovering over.
        getCostAndProduction(buttonName);

        //Finds the text components within the popout window and modifies them to the values acquired in the function ran prior.
        instantiatedPopoutWindow.transform.Find("Cost").Find("Costs").transform.GetComponent<TextMeshProUGUI>().text = buttonCost.x + " Ore" + Environment.NewLine + buttonCost.y + " Energy" + Environment.NewLine + buttonCost.z + " Man Power";
        instantiatedPopoutWindow.transform.Find("Production").Find("Productions").transform.GetComponent<TextMeshProUGUI>().text = buttonProduction.x + " Ore" + Environment.NewLine + buttonProduction.y + " Energy" + Environment.NewLine + buttonProduction.z + " Man Power";
    }

    public void mouseHoverExit()
    {
        //Removes the popout window.
        Destroy(instantiatedPopoutWindow);
    }

    void generateButtons()
    {
        //Generates the buttons.
        generateButton("BuyMine");
        generateButton("BuyHouse");
        generateButton("BuyPowerplant");
        generateButton("BuyRocketstation");
    }

    void generateButton(string buildingName)
    {
        generatedButtonAmount += 1;

        //Addss the button prefab to the scene.
        GameObject buttonInstance = Instantiate(BuyButton);
        buttonInstance.transform.SetParent(this.transform);
        buttonInstance.name = buildingName;
        buttonInstance.GetComponentInChildren<TextMeshProUGUI>().text = buildingName;

        EventTrigger eventTrigger = buttonInstance.GetComponent<EventTrigger>();

        //Adds the event entries.
        EventTrigger.Entry pointerEnterEntry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerEnter
        };
        EventTrigger.Entry pointerExitEntry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerExit
        };

        //Connects the event entries to the proper methods/functions.
        pointerEnterEntry.callback.AddListener((eventData) =>
        {
            mouseHoverOverButton(buildingName);
        });
        pointerExitEntry.callback.AddListener((eventData) =>
        {
            mouseHoverExit();
        });

        eventTrigger.triggers.Add(pointerEnterEntry);
        eventTrigger.triggers.Add(pointerExitEntry);
        
        if (generatedButtonAmount > 4)
        {
            //Extends the scrollable menu.
            rectTransform.pivot = new Vector2(0f, rectTransform.pivot.y);
            Vector2 xSize = rectTransform.sizeDelta;
            xSize.x += 185;
            rectTransform.sizeDelta = xSize;
        }
    }

    void getCostAndProduction(string buttonName)
    {
        //Checks which button matches the name of the "buttonName" which is inputed manually in the Event Trigger component on the buttons, and sets the variables "buttonCost" and "buttonProduction" to their new values which are then used when displaying the popout window.
        switch (buttonName)
        {
            case "BuyMine":
                buttonCost = new Vector3(200, 50, 10); //COST (ORE, ENERGY, MANPOWER)
                buttonProduction = new Vector3(50, 0 , 0); //PRODUCTION (ORE, ENERGY, MANPOWER)
                break;
            
            case "BuyHouse":
                buttonCost = new Vector3(200, 50, 0); //COST (ORE, ENERGY, MANPOWER)
                buttonProduction = new Vector3(50, 0 , 0); //PRODUCTION (ORE, ENERGY, MANPOWER)
                break;

            case "BuyRocketstation":
                buttonCost = new Vector3(1000, 500, 500); //COST (ORE, ENERGY, MANPOWER)
                buttonProduction = new Vector3(50, 0 , 0); //PRODUCTION (ORE, ENERGY, MANPOWER)
                break;

            case "BuyPowerplant":
                buttonCost = new Vector3(200, 0, 10); //COST (ORE, ENERGY, MANPOWER)
                buttonProduction = new Vector3(50, 0 , 0); //PRODUCTION (ORE, ENERGY, MANPOWER)
                break;
        }
    }
}