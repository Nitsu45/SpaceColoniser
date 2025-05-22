using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseGrid : MonoBehaviour
{
    [SerializeField] GameObject Canvas;
    [SerializeField] GameObject PurchasePopOut;

    public GameObject UIScript;
    GameObject instantiatedPopoutWindow;

    Vector3 costOreEnergyManpower = new Vector3(1, 2, 3);
    Vector3 buttonCost;
    Vector3 buttonProduction;
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

    void getCostAndProduction(string buttonName)
    {
        string buildingType = "";
        //Checks which button matches the name of the "buttonName" which is inputed manually in the Event Trigger component on the buttons, and sets the variables "buttonCost" and "buttonProduction" to their new values which are then used when displaying the popout window.
        ConstructionMechanics CM = UIScript.GetComponent<ConstructionMechanics>();
        CM.GetBuildingByName(buttonName);

        switch (buttonName)
        {
            case "BuyMine":
                buildingType = "mine";
                break;

            case "BuyHouse":
                buildingType = "house";
                break;

            case "BuyRocketstation":
                buildingType = "rocketstation";
                break;

            case "BuyPowerplant":
                buildingType = "powerplant";
                break;
            default:
                return;
        }

        GameObject Building = CM.GetBuildingByName(buildingType);
        
        int[] costs = Building.GetComponent<BuildingScript>().GetConstructionCosts();
        int[] production = Building.GetComponent<BuildingScript>().GetResourceProduction();

        buttonCost = new Vector3(costs[0], costs[1], costs[2]); //COST (ORE, ENERGY, MANPOWER)
        buttonProduction = new Vector3(production[0], production[1], production[2]); //PRODUCTION (ORE, ENERGY, MANPOWER)
        //Destroy(Building);

    }
}