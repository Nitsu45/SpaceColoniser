using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    //Building BuildingName
    public string BuildingName = "";
    //manpower mechanics
    //manpower can be assigned to the building. It needs a minium of people assigned to operate
    public int maxManpower = 0; // the maximum amount of manpower
    //Build costs
    public string dependendTechnology = "";
    public int buildingHealth = 100; // Health of the building. Treat it as if it were percent % 
    public int oreCost = 0;
    public int energyCost = 0; //energy is a constant cost, meaning it doesn't get substracted one time during construction, but instead occupys this amount of energy as long as it exists
    public int manpowerCost = 0;
    public int coalCost = 0;
    public int uraniumCost = 0;
    public int waterCost = 0;
    public int researchPointsCosts = 0;
    public int foodCost = 0;
    public int maschinepartsCost = 0;
    public int specialtoolsCost = 0;
    public int rareEarthsCost = 0;


    //Resource generation
    public int oreProduction = 0; //occupies array field number 0
    public int energyProduction = 0; //occupies array field number 1
    public int manpower = 0; //occupies array field number 2
    public int coal = 0; //occupies array field number 3
    public int uranium = 0; //occupies array field number 4
    public int water = 0; //occupies array field number 5
    public int researchPoints = 0; //occupies array field number 6
    public int food = 0; //occupies array field number 7
    public int maschineparts = 0; //occupies array field number 8
    public int specialtools = 0; //occupies array field number 9
    public int rareEarths = 0; //occupies array field number 10

    //Constant Consumption
    public int oreConsumption = 0; //occupies array field number 0
    public int energyConsumption = 0; //occupies array field number 1
    public int manpowerAssigned = 0; //occupies array field number 2
    public int coalConsumption = 0; //occupies array field number 3
    public int uraniumConsumption = 0; //occupies array field number 4
    public int waterConsumption = 0; //occupies array field number 5
    public int researchPointsConsumption = 0; //occupies array field number 6
    public int foodConsumption = 0; //occupies array field number 7
    public int maschinepartsConsumption = 0; //occupies array field number 8
    public int specialtoolsConsumption = 0; //occupies array field number 9
    public int rareEarthsConsumption = 0; //occupies array field number 10


    public Inventory Costs = new Inventory(new Resource().resourceNamePosition);
    public Inventory Production = new Inventory(new Resource().resourceNamePosition);
    public Inventory ConstantResourceConsumption = new Inventory(new Resource().resourceNamePosition);
    //Methods for functionality

    public BuildingScript()
    {
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

    //function for getting the construction cost
    //When making changes to the next two Methods (GetConstructionCosts and GetResourceProduction) please make sure you use the same order as in the resource class for the resources
    public int[] GetConstructionCosts()
    {
        return new int[] { oreCost, rareEarthsCost, coalCost, uraniumCost, waterCost, energyCost, researchPointsCosts, manpowerCost, foodCost, maschinepartsCost, specialtoolsCost, };
    }
    public int[] GetResourceProduction()
    {
        return new int[] { oreProduction, rareEarths, coal, uranium, water, energyProduction, researchPoints, manpower, food, maschineparts, specialtools};
    }
    public int[] GetConstantResourceConsumption()
    {
        return new int[] {oreConsumption, rareEarthsConsumption, coalConsumption, uraniumConsumption, waterConsumption, energyConsumption, researchPointsConsumption, manpowerAssigned, foodConsumption, maschinepartsConsumption, specialtoolsConsumption};
    }

    public void fillingInventory(Inventory InventoryToFillUp, int[] amount, string[] resourceNames)
    {
        
        for (int i = 0; i < resourceNames.Length; i++)
        {
            //Debug.Log($"Filling up resource:{resourceNames[i]} with amount: {amount[i]}");
            InventoryToFillUp.AddToInventory(resourceNames[i], amount[i]);
        }    
    
    }
    public void setEnergy(int amount)
    {
        energyProduction = amount;
    }
    public int getEnergy()
    { 
        return energyProduction;
    }

}
