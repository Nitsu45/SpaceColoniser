using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketStation : BuildingScript
{
    public RocketStation()
    {
        BuildingName = "rocket station";
        oreCost = 1000;
        energyConsumption = 500;
        manpowerAssigned = 500;

        //auffüllen der Inventare mit den Eigenschaften des Gebäudetypes
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
        
    }
}
