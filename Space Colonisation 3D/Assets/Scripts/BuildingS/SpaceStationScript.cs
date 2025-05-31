using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStationScript : BuildingScript
{
 
    public SpaceStationScript()
    {
        BuildingName = "spacestation";
        energyProduction = 100;
        manpower = 100;
        oreCost = 1000;
        energyConsumption = 0;
        manpowerAssigned = 0;

        //auffüllen der INventare mit den Eigenschaften des Gebäudetypes
        // Debug.Log("Filling up Costs");
        fillingInventory(Costs, GetConstructionCosts(), new Resource().resourceNamePosition);
        // Debug.Log("Filling up Production");
        fillingInventory(Production, GetResourceProduction(), new Resource().resourceNamePosition);
        // Debug.Log("Filling up Consumption");
        fillingInventory(ConstantResourceConsumption, GetConstantResourceConsumption(), new Resource().resourceNamePosition);
    }

    


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
      /*  string[] resourceCheck = Production.ResourcesStoredInInventory();
        // Debug.Log($"There is {energyProduction} from energy currently in this spacestation");
        for (int i = 0; i < Production.GetLenghtOfInventory(); i++)
         {
             Debug.Log($"There is {Production.GetResourceAmount(resourceCheck[i])} from {resourceCheck[i]} currently in this spacestation");
         } */
    }
}
