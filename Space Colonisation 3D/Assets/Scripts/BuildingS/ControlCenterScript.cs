using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCenterScript : BuildingScript
{

    public ControlCenterScript()
    {
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
        
    }
}
