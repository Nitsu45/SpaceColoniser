using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

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
    public float tickTimer = 10f;
    public string planetName;
    public bool hasRocketStation = false;

    public Inventory planetStorage = new Inventory(new Resource().resourceNamePosition);
    public Inventory planetProduction = new Inventory(new Resource().resourceNamePosition);
    public Inventory planetConsumption = new Inventory(new Resource().resourceNamePosition);
    List<GameObject> colonyBuildingsList = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        ConstructionScript = UIScript.GetComponent<ConstructionMechanics>();
        //Adding a value in case non is added manually just to avoid bugs
        if (planetName == null) planetName = "";
        //the routine to update the resources
        StartCoroutine(ResourceUpdate());
    }

    // Update is called once per frame
    void Update()
    {
        //checkBuildingsList();
        
    }
    void checkBuildingsList()
    {
        //Zuerst zusammenzählen aller Resourcen Produktion
        //Dann abziehen der Verbrauchs


    }


    //Check buildings list and adjust resource production
    /*  void checkBuildingsList()
      {
          int[] temporaryProductionCounter = new int[planetStorage.GetLenghtOfInventory()]; // Array gets initialised later in code because we need to get the lenght of resource array first 
          int[] temporaryConsumptionCounter = new int[planetStorage.GetLenghtOfInventory()]; // Array gets initialised later in code because we need to get the lenght of resource array first 

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


      }*/


    //Adding a building to the building-list of that planet

    public void AddingBuildingToColony(GameObject building)
    {
        BuildingScript ConstructedBuildingProperties = building.GetComponent<BuildingScript>();
        string[] BuildingProduction = ConstructedBuildingProperties.Production.ResourcesStoredInInventory();
        string[] BuildingConsumption = ConstructedBuildingProperties.ConstantResourceConsumption.ResourcesStoredInInventory();
       
        //Adding resource production. The loop goes through every resource in the production inventory and adds it and the amount the building produces into the planetary production inventory
        for (int i = 0; i < BuildingProduction.Length; i++)
        {
            // Debug.Log($" Adding {BuildingProduction[i]} to Colony. Amount stored in constructed Building Production Inventory: {ConstructedBuildingProperties.Production.GetResourceAmount(BuildingProduction[i])} ");
            if(!planetProduction.AddToInventory(BuildingProduction[i], ConstructedBuildingProperties.Production.GetResourceAmount(BuildingProduction[i]))) Debug.Log($"Resource: {BuildingProduction[i]} konnte nicht hinzugefügt werden");
        }
        //Adding resource costs The loop goes through every resource in the Consumption inventory and adds it and the amount the building consume into the planetary consumption inventory
        for (int i = 0; i < BuildingConsumption.Length; i++)
        {
            planetConsumption.AddToInventory(BuildingConsumption[i], ConstructedBuildingProperties.ConstantResourceConsumption.GetResourceAmount(BuildingConsumption[i]));
        } 
        colonyBuildingsList.Add(building);


    }
    //Deleting a building from the colony
    public void DeletingBuildingFromColony(GameObject building)
    {
        //substracting resource production

        //substracting resource costs
        colonyBuildingsList.Remove(building);
    }



    //Resource update that adds the resources every 10 seconds
    IEnumerator ResourceUpdate()
    {
        while (true)
        {
            ResourceIncome();
            yield return new WaitForSecondsRealtime(tickTimer);
        }
    }
    void ResourceIncome()
    {
        //normal resources
        string[] planetaryResources = planetStorage.ResourcesStoredInInventory();
        
        for (int i = 0; i < planetaryResources.Length; i++)
        {
            int ResourceProduction = planetProduction.GetResourceAmount(planetaryResources[i]);
            //Debug.Log($"Produktion von {planetaryResources[i]} beträgt: {ResourceProduction} ");
            int ResourceConsumption = planetConsumption.GetResourceAmount(planetaryResources[i]);
            //Debug.Log($"Verbrauch von {planetaryResources[i]} beträgt: {ResourceConsumption} ");
            if (new Resource().IsResourceStatic(planetaryResources[i]))
            {
                if(!planetStorage.SetResourceAmount(planetaryResources[i], ResourceProduction - ResourceConsumption)) Debug.Log("Error by adding Resource");
            } 
            else if (!planetStorage.AddToInventory(planetaryResources[i], ResourceProduction - ResourceConsumption)) Debug.Log("Error by adding Resource");

        }
        //static resources
        

    }

    int[] NumerateBuildings()
    {
        



        return new int[0];
    }
    
    public void getStarterResources()
    {
        //Adding starter resources 
        planetStorage.AddToInventory("ore",400);
        AddingBuildingToColony(Instantiate(ConstructionScript.spacestation));
    }

}
