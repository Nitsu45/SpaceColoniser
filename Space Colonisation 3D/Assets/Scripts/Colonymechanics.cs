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

    public int[] planetStorage = new int[3] { 0, 0, 0 };
    List<GameObject> colonyBuildingsList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        ConstructionScript = UIScript.GetComponent<ConstructionMechanics>();
        //Hinzufügen eines Wertes zu planetName falls keiner zugewiesen ist um abstürze zu vermeiden
        if (planetName == null) planetName = "";
        //Adding starter resources
        planetStorage[0] = 400;
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
            BuildingScript ConstructedBuildingProperties = item.GetComponent<BuildingScript>();
            int[] resourceProduction = ConstructedBuildingProperties.GetResourceProduction();
            int[] resourceConsumption = ConstructedBuildingProperties.GetConstructionCosts();
            switch (ConstructedBuildingProperties.Name)
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
   

    //Adding a building to the building-list of that planet

    public void AddingBuildingToColony(GameObject Building)
    {
        colonyBuildingsList.Add(Building);
        checkBuildingsList();
    }
    //Deleting a building from the colony
    public void DeletingBuildingFromColony(string buildingName)
    {
        //colonyBuildingsList.Remove(buildingName);
    }



    //Resource update that adds the resources every 10 seconds
    IEnumerator ResourceUpdate()
    {
        while (true)
        {
            planetStorage[0] = planetStorage[0] + oreProduction;
            planetStorage[1] = energyProduction + 50;
            planetStorage[2] = manpower + 50;
            yield return new WaitForSecondsRealtime(tickTimer);
        }
    }

    int[] NumerateBuildings()
    {
        



        return new int[0];
    }
    

}
