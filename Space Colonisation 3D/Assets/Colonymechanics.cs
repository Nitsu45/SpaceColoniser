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
    public float TickTimer = 60f;


    int[] planetStorage = new int[3] {0,0,0};
    List<string> colonyBuildingsList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        //Checking already existing Buildings
        checkBuildingsList();
        //the routine to update the resources
        StartCoroutine(ResourceUpdate());
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    void checkBuildingsList()
    {
        int[] temporaryProductionCounter = new int[3];
        
        //Check buildings list and adjust resource production
        foreach (var item in colonyBuildingsList)
        {
            switch (item)
            {

                case "mine":
                    temporaryProductionCounter[0] = temporaryProductionCounter[0] + 50;
                    break;
                case "powerplant":
                    temporaryProductionCounter[1] = temporaryProductionCounter[1] + 50;
                    break;
                case "house":
                    temporaryProductionCounter[2] = temporaryProductionCounter[2] + 50;
                    break;
                default:
                    Debug.Log("No resource Building");
                    break;
            }
        }
        oreProduction = temporaryProductionCounter[0];
        energyProduction = temporaryProductionCounter[1];
        manpower = temporaryProductionCounter[2];
    }

    void UpdateDisplay()
    {
        OreProductionDisplay.text = $"Ore Production: {oreProduction}/m";
        OreDisplay.text = $"Ore: {planetStorage[0]}";
        EnergyProductionDisplay.text = $"Energy Production: {planetStorage[1]}";
        ManPowerDisplay.text = $"Man Power:  {planetStorage[2]}";
    }



    //Resource update that adds the resources every 10 seconds
    IEnumerator ResourceUpdate()
    {
        while(true)
        {
            planetStorage[0] = planetStorage[0] + oreProduction;
            planetStorage[1] = energyProduction;
            planetStorage[2] = manpower;
            yield return new WaitForSecondsRealtime(TickTimer);
        }
    }
    //Button functions

    public void BuyMineButton()
    {
        if (planetStorage[0] >= 200)
        {
            colonyBuildingsList.Add("mine");
            planetStorage[0] = planetStorage[0] - 200;
            checkBuildingsList();
        }
        else
        {
            Debug.Log("Not enough Ore!");
        }
     
    }
    public void BuyPPButton()
    {
        if (planetStorage[0] >= 200)
        {
            colonyBuildingsList.Add("powerplant");
            planetStorage[0] = planetStorage[0] - 200;
            checkBuildingsList();
        }
        else
        {
            Debug.Log("Not enough Ore!");
        }
    }
    public void BuyHouseButton()
    {
        if (planetStorage[0] >= 200)
        {
            colonyBuildingsList.Add("house");
            planetStorage[0] = planetStorage[0] - 200;
            checkBuildingsList();
        }
        else
        {
            Debug.Log("Not enough Ore!");
        }
    }

}
