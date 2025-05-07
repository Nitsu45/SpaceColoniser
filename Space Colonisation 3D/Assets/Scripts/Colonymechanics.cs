using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Colonymechanics : MonoBehaviour
{
    //Reference
    public GameObject UIScript;
    ConstructionMechanics ConstructionScript;

    //Global variables
    public int oreProduction = 0;
    public int energyProduction = 0;
    public int manpower = 0;
    public int energyConsumption;
    public int manpowerConsumption;
    public float tickTimer = 60f;
    public string planetName;
    public bool hasRocketStation = false;

    int[] buildingCounter;
    public int[] planetStorage = new int[3] { 0, 0, 0 };
    List<string> colonyBuildingsList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        buildingCounter = NumerateBuildings();
        ConstructionScript = UIScript.GetComponent<ConstructionMechanics>();
        //Hinzufügen eines Wertes zu planetName falls keiner zugewiesen ist um abstürze zu vermeiden
        if (planetName == null) planetName = "";
        //Since it's the first planet the player get's 400 starter Ore and a Power Plant and a house
        planetStorage[0] = 400;
        AddingBuildingToColony("powerplant");
        AddingBuildingToColony("house");
        planetStorage[2] = 200;
        //Checking already existing Buildings
        checkBuildingsList();
        //the routine to update the resources
        StartCoroutine(ResourceUpdate());
        /*
        GameObject mine1 = Instantiate(mine, new Vector3(0, 0, 0), Quaternion.identity, transform);
        MineScript mine1Script = mine1.GetComponent<MineScript>();
        int[] costs = mine1Script.GetConstructionCosts();
        Debug.Log($"{costs[0]}+{costs[1]}+{costs[2]}"); */
    }

    // Update is called once per frame
    void Update()
    {
        checkBuildingsList();
    }
    //Check buildings list and adjust resource production
    void checkBuildingsList()
    {
        int[] temporaryProductionCounter = new int[3];

        // They first count how many resources the colony produces before assigning the value
        foreach (var item in colonyBuildingsList)
        {
            //Funktion zum zählen aller einzelnen Einträge des jeweiligen Gebäude Types.
            BuildingScript ConstructedBuildingProperties = ConstructionScript.GettingBuildingByName(item).GetComponent<BuildingScript>();
            int[] resourceProduction = ConstructedBuildingProperties.GetResourceProduction();
            int[] resourceConsumption = ConstructedBuildingProperties.GetConstructionCosts();
            switch (item)
            {
                case "mine":
                    //Production
                    temporaryProductionCounter[0] = temporaryProductionCounter[0] + resourceProduction[0];
                    oreProduction = temporaryProductionCounter[0];
                    //Consumption
                    //Energy

                    //Manpower
                    /* 
                     buildingCounter[buildingScript.buildingID]++; 
                     */

                    break;
                case "powerplant":
                    //Production
                    temporaryProductionCounter[1] = temporaryProductionCounter[1] + resourceProduction[1];
                    energyProduction = temporaryProductionCounter[1];
                    //Consumption

                    break;
                case "house":
                    //Production
                    temporaryProductionCounter[2] = temporaryProductionCounter[2] + resourceProduction[2];
                    manpower = temporaryProductionCounter[2];
                    //Consumption

                    break;
                case "rocketstation":
                    //Production
                    //Consumption
                    break;
                case "spacestation":
                    //Production
                    //Consumption
                    break;
                default:
                    Debug.Log("No resource Building");
                    break;
            }
        }



    }
    //Checks the number of buildings and adjusts resource production and consumption
    void CheckBuildingCounter()
    {


        // They first count how many resources the colony produces before assigning the value
        for (int i = 0; i < buildingCounter.Length; i++)
        {

            //Funktion zum zählen aller einzelnen Einträge des jeweiligen Gebäude Types.
            
            switch (i)
            {
                case 1:
                    //Das Problem ist, wenn ich die ID bereits hab, müsste es einen mechanismus gegebn, der es mir erlaubt alle Klassen die "BuildingScript" untergeordnet sind zu durchlaufen und anschließend doe Produktions und Kostenwerte abzufragen. 
                    //Am besten wäre es eine Liste aller existenten Gebäude abzufragen und diese numerisch durchzugehen und die ID abzufragen. Wenn der Id wert für das entsprechende Feld gefunden ist
                    //können die Produktions und Verbreauchswerte abgefragt, und mit der Zahl der Gebäude mulipliziert werden.
                    BuildingScript ConstructedBuildingProperties = ConstructionScript.GettingBuildingByName("mine").GetComponent<BuildingScript>();
                    int[] resourceProduction = ConstructedBuildingProperties.GetResourceProduction();
                    int[] resourceConsumption = ConstructedBuildingProperties.GetConstructionCosts();
                    //Production

                    //Consumption
                    //Energy

                    //Manpower

                    break;
                case 2:
                    //Production 
                   
                    //Consumption

                    break;
                case 3:
                    //Production
                    
                    //Consumption

                    break;
                case 4:
                    //Production
                    //Consumption
                    break;
                case 5:
                    //Production
                    //Consumption
                    break;
                default:
                    Debug.Log($"Building is not valid! Building ID: {i}");
                    break;
            }
        }

    }


    //Adding a building to the building-list of that planet

    public void AddingBuildingToColony(string buildingName)
    {
        colonyBuildingsList.Add(buildingName);
        checkBuildingsList();
    }
    //Deleting a building from the colony
    public void DeletingBuildingFromColony(string buildingName)
    {
        colonyBuildingsList.Remove(buildingName);
    }



    //Resource update that adds the resources every 10 seconds
    IEnumerator ResourceUpdate()
    {
        while (true)
        {
            planetStorage[0] = planetStorage[0] + oreProduction;
            planetStorage[1] = energyProduction;
            planetStorage[2] = manpower;
            yield return new WaitForSecondsRealtime(tickTimer);
        }
    }

    int[] NumerateBuildings()
    {
        



        return new int[0];
    }
    

}
