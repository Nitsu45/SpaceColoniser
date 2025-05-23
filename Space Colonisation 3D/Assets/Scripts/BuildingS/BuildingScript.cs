using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    //Building Name
    public string Name = "";
    //manpower mechanics
    public int manPowerAssigned = 0; //manpower can be assigned to the building. It needs a minium of people assigned to operate
    public int maxManpower = 0; // the maximum amount of manpower
    //Build costs
    public string DependendTechnology = "";
    public int BuildingHealth = 100; // Health of the building. Treat it as if it were percent % 
    public int oreCost = 0;
    public int energyCost = 0; //energy is a constant cost, meaning it doesn't get substracted one time during construction, but instead occupys this amount of energy as long as it exists
    public int coalCost = 0; 
    public int UraniumCost = 0; 
    public int waterCost = 0; 
    public int foodCost = 0; 
    public int maschinepartsCost = 0; 
    public int specialtoolsCost = 0; 
    public int rareEarthsCost = 0; 


    //Resource generation
    public int oreProduction = 0; //occupies array field number 0
    public int energyProduction = 0; //occupies array field number 1
    public int manpower = 0; //occupies array field number 2
    public int coal = 0; //occupies array field number 3
    public int Uranium = 0; //occupies array field number 4
    public int water = 0; //occupies array field number 5
    public int ResearchP = 0; //occupies array field number 6
    public int food = 0; //occupies array field number 7
    public int maschineparts = 0; //occupies array field number 8
    public int specialtools = 0; //occupies array field number 9
    public int rareEarths = 0; //occupies array field number 10
    //Methods for functionality


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //function for getting the construction cost
    public int[] GetConstructionCosts()
    {
        return new int[] { oreCost, energyCost, coalCost, UraniumCost, waterCost, foodCost, maschinepartsCost, specialtoolsCost, rareEarthsCost};
    }
    public int[] GetResourceProduction()
    {
        return new int[] { oreProduction, energyProduction, manpower, coal, Uranium, water, ResearchP, food, maschineparts, specialtools, rareEarths};
    }



}
