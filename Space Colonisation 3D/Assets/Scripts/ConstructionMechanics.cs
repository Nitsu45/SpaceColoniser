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
     The function looks complicated but it essentially just checks what Gameobject is referenced by the name that is passed as a string.
     Then it get's the script of that Gameobject and calls the "GetConstructionCosts" function of that script. As the name suggest this get's the costs of constructing the building.
     When the Colony has enough resources, these are saved in the planetInventory array, then the function returns true and the player get's to place the building.
     */

    public bool ConstructingBuilding(string buildingName, Colonymechanics SelectedColony )
    {
        GameObject ConstructedBuilding = GettingBuildingByName(buildingName);
        BuildingScript ConstructedBuildingProperties = ConstructedBuilding.GetComponent<BuildingScript>();
        if(CheckingConstructionCosts(ConstructedBuildingProperties.GetConstructionCosts(),SelectedColony.planetStorage))
        {
            StartCoroutine(buildingPlacement(ConstructedBuilding));
            //if the building coroutine succeeds, the building class should then call the add building function of the colony mechanics class
            SelectedColony.AddingBuildingToColony(ConstructedBuilding);
            SelectedColony.planetStorage = SubstractingConstrctuionCosts(buildingName, SelectedColony.planetStorage);



            return true;
        }else return false;


    }
    //Checking if enough resources are available for construction
    public bool CheckingConstructionCosts(int[] costs, int[] availableResources)
    {
        for (int i = 0; i < costs.Length; i++)
        {
            if (costs[i] > availableResources[i]) return false;
        }

        return true;
    }
    //Substracting the resources from the colony after the building has succesfully been placed.
    public int[] SubstractingConstrctuionCosts(string buildingName, int[] planetInventory)
    {
        GameObject ConstructedBuilding = GettingBuildingByName(buildingName);
        BuildingScript ConstructedBuildingProperties = ConstructedBuilding.GetComponent<BuildingScript>();
        int[] ConstructionCosts = ConstructedBuildingProperties.GetConstructionCosts();

        for (int i = 0; i < ConstructionCosts.Length; i++)
        {
            planetInventory[i] = planetInventory[i] - ConstructionCosts[i];

        }
        return planetInventory;
    }

    //Gets the respective Gameobject by the name of it. This is to not have countless references to them in all of the scripts.
    //This way all of the references are in one place and you can get them by using a simple string.
    public GameObject GettingBuildingByName(string buildingName)
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


    //Placing a building
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








}
