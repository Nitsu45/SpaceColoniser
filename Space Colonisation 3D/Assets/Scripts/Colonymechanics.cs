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
    }

    // Update is called once per frame
    void Update()
    {
        checkBuildingsList();
        
    }
    //Check buildings list and adjust resource production
    void checkBuildingsList()
    {
        int[] temporaryProductionCounter = new int[3]; // Array gets initialised later in code because we need to get the lenght of resource array first 
        int[] temporaryConsumptionCounter = new int[3]; // Array gets initialised later in code because we need to get the lenght of resource array first 

        // They first count how many resources the colony produces before assigning the value
        foreach (var item in colonyBuildingsList)
        {
            //Funktion zum zählen aller einzelnen Einträge des jeweiligen Gebäude Types.
            BuildingScript ConstructedBuildingProperties = item.GetComponent<BuildingScript>();
            int[] resourceProduction = ConstructedBuildingProperties.GetResourceProduction();
            int[] resourceConsumption = ConstructedBuildingProperties.GetConstructionCosts();


            for (int i = 0; i < temporaryProductionCounter.Length; i++)
            {
                temporaryProductionCounter[i] = temporaryProductionCounter[i] + resourceProduction[i];
            }
            for (int i = 0; i < temporaryConsumptionCounter.Length; i++)
            {
                temporaryConsumptionCounter[i] = temporaryConsumptionCounter[i] + resourceConsumption[i];
            }
        }
        //assigning the planetary values with the result from counting the buildings production and consumption together
        oreProduction = temporaryProductionCounter[0];
        energyProduction = temporaryProductionCounter[1];
        manpower = temporaryProductionCounter[2];
        energyConsumption = temporaryConsumptionCounter[1];
        manpowerConsumption = temporaryConsumptionCounter[2];


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
            planetStorage[1] = energyProduction + 50 - energyConsumption;
            planetStorage[2] = manpower + 50 - manpowerConsumption;
            yield return new WaitForSecondsRealtime(tickTimer);
        }
    }

    int[] NumerateBuildings()
    {
        



        return new int[0];
    }
    

}
