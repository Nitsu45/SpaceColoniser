using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colonymechanics : MonoBehaviour
{
    //Reference
    public Text OreProductionDisplay;
    public Text OreDisplay;
    public Text EnergyProductionDisplay;
    public Text ManPowerDisplay;



    //Global variables
    public int oreProduction = 0;
    public int energyProduction = 0;
    public int manpower = 0;


    int[] planetStorage = new int[3] {0,0,0};
    List<string> colonyBuildingsList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        //Check buildings list and adjust resource production
        foreach (var item in colonyBuildingsList)
        {
            switch(item)
            {
                
                case "mine":
                    oreProduction =+ 50;
                    break;
                case "energyProduction":
                    energyProduction =+ 50;
                    break;
                case "house":
                    manpower =+ 50;
                    break;
                default:
                    Debug.Log("No resource Building");
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        planetStorage[0] = planetStorage[0] + oreProduction; 
        planetStorage[1] = energyProduction;
        planetStorage[2] = manpower;
        OreProductionDisplay.text = $"Ore Production: {oreProduction}";
        OreDisplay.text = $"Ore: {planetStorage[0]}";
        EnergyProductionDisplay.text = $"Energy Production: {planetStorage[1]}";
        ManPowerDisplay.text = $"Man Power:  {planetStorage[2]}";
    }
}
