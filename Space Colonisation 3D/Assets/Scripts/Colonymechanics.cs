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



    //Global variables
    public int oreProduction = 0;
    public int energyProduction = 0;
    public int manpower = 0;
    public float TickTimer = 60f;
    

    public int[] planetStorage = new int[3] {0,0,0};
    List<string> colonyBuildingsList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        //Since it's the first planet the player get's 400 starter Ore so he can build a Power Plant and a mine.
        planetStorage[0] = 400;
        planetStorage[1] = 200;
        planetStorage[2] = 200;
        //Checking already existing Buildings
        checkBuildingsList();
        //the routine to update the resources
        StartCoroutine(ResourceUpdate());
        /*
        GameObject mine1 = Instantiate(mine, new Vector3(0, 0, 0), Quaternion.identity, transform);
        MineScript mine1Script = mine1.GetComponent<MineScript>();
        int[] costs = mine1Script.GetConstructionCosts();
        Debug.Log($"{costs[0]}+{costs[1]}+{costs[2]}"); */
    }

    // Update is called once per frame
    void Update()
    {
        checkBuildingsList();
    }
    //Check buildings list and adjust resource production
    void checkBuildingsList()
    {
        int[] temporaryProductionCounter = new int[3];
        
        // They first count how many resources the colony produces before assigning the value
        foreach (var item in colonyBuildingsList)
        {
            switch (item)
            {
                case "mine":
                    temporaryProductionCounter[0] = temporaryProductionCounter[0] + 50;
                    oreProduction = temporaryProductionCounter[0];
                    break;
                case "powerplant":
                    temporaryProductionCounter[1] = temporaryProductionCounter[1] + 50;
                    energyProduction = temporaryProductionCounter[1];
                    break;
                case "house":
                    temporaryProductionCounter[2] = temporaryProductionCounter[2] + 50;
                    manpower = temporaryProductionCounter[2];
                    break;
                default:
                    Debug.Log("No resource Building");
                    break;
            }
        }
        
        
        
    }



    //Adding a building to the building-list of that planet

    public void AddingBuildingToColony(string buildingName)
    {
        colonyBuildingsList.Add(buildingName);
    }
    //Deleting a building from the colony
    public void DeletingBuildingFromColony(string buildingName)
    {
        colonyBuildingsList.Remove(buildingName);
    }



    //Resource update that adds the resources every 10 seconds
    IEnumerator ResourceUpdate()
    {
        while(true)
        {
            planetStorage[0] = planetStorage[0] + oreProduction;
           // planetStorage[1] = energyProduction;
           // planetStorage[2] = manpower;
            yield return new WaitForSecondsRealtime(TickTimer);
        }
    }

    

}
