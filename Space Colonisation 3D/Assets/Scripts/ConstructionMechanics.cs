using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionMechanics : MonoBehaviour
{

    //Prefabs
    public GameObject template;
    public GameObject mine;
    public GameObject powerplant;
    public GameObject house;
    public GameObject spacestation;
    public GameObject rocketstation;

    // public GameObject[] Tech1Buildings = new GameObject[9];
    GameObject[] ListOfBuildings;
    



    // Start is called before the first frame update
    void Start()
    {
        CreateListOfBuildings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }







    //Constructing a building
    /*
     The function looks complicated but it essentially just checks what Gameobject is referenced by the BuildingName that is passed as a string.
     Then it get's the script of that Gameobject and calls the "GetConstructionCosts" function of that script. As the BuildingName suggest this get's the costs of constructing the building.
     When the Colony has enough resources, these are saved in the planetInventory array, then the function returns true and the player get's to place the building.
     */

    public bool ConstructingBuilding(string buildingName, Colonymechanics SelectedColony )
    {
        GameObject ConstructedBuilding = GetBuildingByName(buildingName);
        BuildingScript ConstructedBuildingProperties = ConstructedBuilding.GetComponent<BuildingScript>();
        if(CheckingConstructionCosts(ConstructedBuildingProperties.Costs,SelectedColony.planetStorage))
        {
            StartCoroutine(buildingPlacement(ConstructedBuilding, SelectedColony));
            
            if (buildingName == "rocketstation") SelectedColony.hasRocketStation = true;
           
            return true;
        }else return false;


    }
    //Checking if enough resources are available for construction
    public bool CheckingConstructionCosts(Inventory Costs, Inventory planetstorage)
    {
        string[] resourceName = Costs.ResourcesStoredInInventory();
        for (int i = 0; i < resourceName.Length; i++)
        {

            if (Costs.GetResourceAmount(resourceName[i]) > planetstorage.GetResourceAmount(resourceName[i])) return false;

        }

        return true;
    }
    //Substracting the resources from the colony after the building has succesfully been placed.
    public void SubstractingConstructionCosts(Inventory Costs, Inventory planetstorage)
    {
        string[] resourceName = Costs.ResourcesStoredInInventory();
        for (int i = 0; i < resourceName.Length; i++)
        {
            planetstorage.SubstracFromInventory(resourceName[i], Costs.GetResourceAmount(resourceName[i]));
        }
    }

    //Gets the respective Gameobject by the BuildingName of it. This is to not have countless references to them in all of the scripts.
    //This way all of the references are in one place and you can get them by using a simple string.
    public GameObject GetBuildingByName(string buildingName)
    {
        switch (buildingName)
        {
            case "mine":
                return mine;
            case "powerplant":
                return powerplant;
            case "house":
                return house;
            case "rocketstation":
                return rocketstation;
            case "spacestation":
                return spacestation;
            default:
                return template;
        }
    }


    //Listing all Gameobjects with the "Buildings"-tag and saving it in an Array
    //No function yet
    void CreateListOfBuildings()
    {
        ListOfBuildings = GameObject.FindGameObjectsWithTag("Buildings");
    }

    void AbortConstruction()
    {


    }


    //Placing a building
    IEnumerator buildingPlacement(GameObject building, Colonymechanics SelectedColony)
    {
        GameObject placedBuilding = Instantiate(building);
        BuildingScript buildingScript = building.GetComponent<BuildingScript>();
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

                    SelectedColony.AddingBuildingToColony(building);
                    SubstractingConstructionCosts(buildingScript.Costs, SelectedColony.planetStorage);

                    yield break;
                }
                if(Input.GetKey(KeyCode.Escape))
                {
                    Destroy(placedBuilding);
                    yield break;
                }
            }
            yield return null;
        }
    }








}
