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
    public Camera mainCamera;
    public Text OreProductionDisplay;
    public Text OreDisplay;
    public Text EnergyProductionDisplay;
    public Text ManPowerDisplay;



    //Global variables
    public int oreProduction = 0;
    public int energyProduction = 0;
    public int manpower = 0;
    public float TickTimer = 60f;


    //Prefabs
    public GameObject mine;
    

    int[] planetStorage = new int[3] {0,0,0};
    List<string> colonyBuildingsList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        //Since it's the first planet the player get's 400 starter Ore so he can build a Power Plant and a mine.
        planetStorage[0] = 400;
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
        UpdateDisplay();
        lookAroundPlanet();
        
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

    IEnumerator buildingPlacement(GameObject building)
    {
        GameObject placedBuilding = Instantiate(building);
        while (true)
        {
            //Loops until player has chosen the position of the building.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                placedBuilding.transform.position = hit.point;
                Vector3 directionToPlanet = (transform.position - placedBuilding.transform.position).normalized;

                Quaternion planetToRotation = Quaternion.FromToRotation(placedBuilding.transform.up, directionToPlanet) * placedBuilding.transform.rotation;
                placedBuilding.transform.rotation = planetToRotation;

                if (Input.GetKey(KeyCode.Mouse0))
                {
                    placedBuilding.AddComponent<BoxCollider>();
                    yield break;
                }
            }
            yield return null;
        }
    }

    void lookAroundPlanet()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * 20;

            mainCamera.transform.RotateAround(transform.position, new Vector3(0, mouseX, 0), 200f * Time.deltaTime);    
        }
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
            StartCoroutine(buildingPlacement(mine));
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
