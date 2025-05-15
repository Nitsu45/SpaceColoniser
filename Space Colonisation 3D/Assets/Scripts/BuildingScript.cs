using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    //Building Name
    public string Name = "";
    //Build costs
    public int oreCost = 0;
    public int energyCost = 0; //energy is a constant cost, meaning it doesn't get substracted one time during construction, but instead occupys this amount of energy as long as it exists
    public int manPowerCost = 0; //manpower is a constant cost, meaning it doesn't get substracted one time during construction, but instead occupys this amount of energy as long as it exists
    //Resource generation
    public int oreProduction = 0;
    public int energyProduction = 0;
    public int manpower = 0;
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
        return new int[] { oreCost, energyCost, manPowerCost };
    }
    public int[] GetResourceProduction()
    {
        return new int[] { oreProduction, energyProduction, manpower };
    }



}
